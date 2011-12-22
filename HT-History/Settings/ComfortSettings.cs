using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Settings
{
    using Columns = IEnumerable<HtHistory.Statistics.Players.IPlayerStatisticCalculator<IEnumerable<HtHistory.Statistics.Players.MatchAppearance>>>;
    using HtHistory.Statistics.Players;

    public class ComfortSettings : Settings
    {
        private readonly string StringColumnSetDefault = "Name;ID;TotMat;TotGoa;ComMat;ComGoa;LeaMat;LeaGoa;CupMat;CupGoa;QuaMat;QuaGoa;FriMat;FriGoa;TotFirst;TotLast";
        private readonly string StringColumnSetTotal = "Name;ID;TotMat;TotGoa;TotGpM;TotWin;TotDraw;TotLost";
        private readonly string StringColumnSetComp = "Name;ID;ComMat;ComGoa;ComGpM;ComWin;ComDraw;ComLost";

        public bool ExcludeForfaits
        {
            get
            {
                try
                {
                    string strEx;
                    if (TryGetValue("excludeForfeits", out strEx))
                    {
                        return bool.Parse(strEx);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
            set
            {
                this["excludeForfeits"] = value.ToString();
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

        private ColumnSet _activeColumnSet;
        public ColumnSet ActiveColumnSet
        {
            get
            {
                if (_activeColumnSet == null)
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

                    _activeColumnSet = ColumnSets.FirstOrDefault(cs => cs.Name == stringColumnSet);

                    if (_activeColumnSet == null)
                    {
                        throw new Exception("The active column set is unknown. This should not happen.");
                    }
                }
                return _activeColumnSet;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("ActiveColumnSet");
                if (!ColumnSets.Contains(value))
                {
                    throw new Exception("Cannot set an unknown colums set active");
                }

                this["activeColumnSet"] = value.Name;

                _activeColumnSet = value;
            }
        }

        private IList<ColumnSet> _columnSets;
        public IList<ColumnSet> ColumnSets
        {
            get
            {
                if (_columnSets == null)
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

                    _columnSets = tempColSet;
                }
                return _columnSets;
            }
            set
            {
                _columnSets = value;

                // clear entrys
                for (int i = this.Count-1; i >= 0; --i)
                {
                   var v = this.ElementAt(i);
                   if (v.Key != null && v.Key.StartsWith("columns:"))
                   {
                       this.Remove(v.Key);
                   }
                }

                // set new entries
                foreach (var v in value)
                {
                    this.Add("columns:" + v.Name, Columns2String(v.Columns));
                }
            }
        }

        private void AddIfNotPresent(IList<ColumnSet> sets, string name, string columns)
        {
            if (sets.FirstOrDefault(cs => cs.Name == name) == null)
            {
                sets.Add(new ColumnSet(name, String2Columns(columns)));
            }
        }
    }
}
