using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Settings
{
    using Columns = IEnumerable<HtHistory.Statistics.Players.IPlayerStatisticCalculator<IEnumerable<HtHistory.Statistics.Players.MatchAppearance>>>;
    using HtHistory.Statistics.Players;
    using System.IO;

    public class ComfortSettings : Settings
    {
        private readonly string StringColumnSetDefault = "Name;ID;TotMat;TotGoa;ComMat;ComGoa;LeaMat;LeaGoa;CupMat;CupGoa;QuaMat;QuaGoa;FriMat;FriGoa;TotFirst;TotLast";
        private readonly string StringColumnSetTotal = "Name;ID;TotStars;TotMat;TotGoa;TotGpM;TotGp90Min;TotMin;TotMpM;TotMotM;TotIn;TotOut;TotBru;TotInj;TotYellow;TotRed;TotFirst;TotLast;TotWin;TotWin%;TotDraw;TotDraw%;TotLost;TotLos%;";
        private readonly string StringColumnSetComp = "Name;ID;ComStars;ComMat;ComGoa;ComGpM;ComGp90Min;ComMin;ComMpM;ComMotM;ComIn;ComOut;ComBru;ComInj;ComYellow;ComRed;ComFirst;ComLast;ComWin;ComWin%;ComDraw;ComDraw%;ComLost;ComLos%;";

        public bool ExcludeForfaits
        {
            get;
            set;
        }

        private ColumnSet _activeColumnSet;
        public ColumnSet ActiveColumnSet
        {
            get
            {
                return _activeColumnSet;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("ActiveColumnSet");
                _activeColumnSet = value;
            }
        }

        public IList<ColumnSet> ColumnSets
        {
            get; set;
        }

        private void LoadForfaits()
        {
            try
            {
                string strEx;
                if (TryGetValue("excludeForfeits", out strEx))
                {
                    ExcludeForfaits = bool.Parse(strEx);
                }
                else
                {
                    ExcludeForfaits = false;
                }
            }
            catch
            {
                ExcludeForfaits = false;
            }
        }
        private void SaveForfaits()
        {
            this["excludeForfeits"] = ExcludeForfaits.ToString();
        }

        private void LoadColumnSets()
        {
            IList<ColumnSet> tempColSet = new List<ColumnSet>();
            foreach (var v in this)
            {
                // be backward compatible:
                if (v.Key.Equals("columns"))
                {
                    tempColSet.Add(new ColumnSet("Custom", String2Columns(v.Value)));
                }

                if (v.Key.StartsWith("columns:"))
                {
                    string setName = v.Key.Substring("columns:".Length);
                    if (setName.Length > 0)
                    {
                        tempColSet.Add(new ColumnSet(setName, String2Columns(v.Value)));
                    }
                }
            }

            AddIfNotPresent(tempColSet, "Default", StringColumnSetDefault);
            AddIfNotPresent(tempColSet, "Total", StringColumnSetTotal);
            AddIfNotPresent(tempColSet, "Competitive", StringColumnSetComp);

            ColumnSets = tempColSet;            
        }
        private void SaveColumnSets()
        {
            // clear entrys
            for (int i = this.Count - 1; i >= 0; --i)
            {
                var v = this.ElementAt(i);
                if (v.Key != null && v.Key.StartsWith("columns"))
                {
                    this.Remove(v.Key);
                }
            }

            // set new entries
            foreach (var v in ColumnSets.SafeEnum())
            {
                string key = "columns:" + v.Name;
                this[key] = Columns2String(v.Columns);                
            }
        }

        private void LoadActiveColumnSet()
        {  
            string stringColumnSet;
            if (ContainsKey("activeColumnSet"))
            {
                stringColumnSet = this["activeColumnSet"];
                if (ColumnSets.FirstOrDefault(cs => cs.Name == stringColumnSet) == null)
                {
                    stringColumnSet = "Default";
                }
            }
            else
            {
                stringColumnSet = "Default";
            }

            ActiveColumnSet = ColumnSets.FirstOrDefault(cs => cs.Name == stringColumnSet);

            if (ActiveColumnSet == null)
            {
                throw new Exception("The active column set is unknown. This should not happen.");
            }
        }
        private void SaveActiveColumnSet()
        {
            if (ActiveColumnSet != null)
            {
                if (!ColumnSets.Contains(ActiveColumnSet))
                {
                    throw new Exception("Cannot set an unknown colums set active");
                }

                this["activeColumnSet"] = ActiveColumnSet.Name;
            }
        }


        public override void Load(string filepath)
        {
            if (File.Exists(filepath))
            {
                base.Load(filepath);
            }

            LoadColumnSets();
            LoadActiveColumnSet();
            LoadForfaits();
        }
        
        public override void Save(string filepath)
        {
            SaveForfaits();
            SaveColumnSets();
            SaveActiveColumnSet();

            base.Save(filepath);
        }

        private void AddIfNotPresent(IList<ColumnSet> sets, string name, string columns)
        {
            if (sets.FirstOrDefault(cs => cs.Name == name) == null)
            {
                sets.Add(new ColumnSet(name, String2Columns(columns)));
            }
        }

        private Columns String2Columns(string columnString)
        {
            foreach (string column in columnString.Split(';'))
            {
                foreach (var v in CalculatorFactory.GetAllCalulators())
                {
                    if (column == v.Identifier)
                    {
                        yield return v;
                    }
                }
            }
        }
        private string Columns2String(Columns columns)
        {
            StringBuilder b = new StringBuilder();

            foreach (var v in columns)
            {
                b.Append(v.Identifier).Append(";");
            }

            return b.ToString();
        }

    }
}
