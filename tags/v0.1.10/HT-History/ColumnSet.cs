using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory
{
    using Columns = System.Collections.Generic.IEnumerable<HtHistory.Statistics.Players.IPlayerStatisticCalculator<System.Collections.Generic.IEnumerable<HtHistory.Statistics.Players.MatchAppearance>>>;

    public class ColumnSet
    {
        private string _name;
        public string Name
        {
            get{ return _name;}
            set
            {
                if (value == null) throw new ArgumentNullException("Name");
                _name = value;
            }
        }
        
        private Columns _colums;
        public Columns Columns
        {
            get { return _colums; }
            set
            {
                if (value == null) throw new ArgumentNullException("Columns");
                _colums = value;
            }
        }

        public ColumnSet(string name, Columns columns)
        {
            Name = name;
            Columns = columns;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
