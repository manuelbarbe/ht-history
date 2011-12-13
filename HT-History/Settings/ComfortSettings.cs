using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory
{
    using Columns = IEnumerable<HtHistory.Statistics.Players.IPlayerStatisticCalculator<IEnumerable<HtHistory.Statistics.Players.MatchAppearance>>>;
    using HtHistory.Statistics.Players;

    public class ComfortSettings : Settings
    {
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

        private Columns _columns = null;
        public Columns Columns
        {
            get
            {
                if (_columns == null)
                {
                    IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> list = new List<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>>(); 
                    string columnString;
                    if (this.ContainsKey("columns"))
                    {
                        columnString = this["columns"];
                    }
                    else
                    {
                        columnString = "Name;TotMat;TotGoa;TotWin;TotDraw;TotLost;TotMotM;TotRed;ComMat;ComGoa;LeaMat;LeaGoa;CupMat;CupGoa;QuaMat;QuaGoa;FriMat;FriGoa;TotFirst;TotLast";
                    }

                    foreach (string column in columnString.Split(';'))
                    {
                        foreach (var v in CalculatorFactory.GetAllCalulators())
                        {
                            if (column == v.Identifier)
                            {
                                list.Add(v);
                            }
                        }
                    }

                    _columns = list;
                }
                return _columns;
            }
            set
            {
                StringBuilder b = new StringBuilder();

                foreach (var v in value)
                {
                    b.Append(v.Identifier).Append(";");
                }

                this["columns"] = b.ToString();

                _columns = value;
            }

        }

    }
}
