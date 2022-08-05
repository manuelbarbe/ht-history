using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class HtObject
    {
        protected HtObject(int id) { ID = id; }

        public int ID { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return GetType().Equals(obj.GetType()) && ID.Equals((obj as HtObject).ID);

            // TODO:check with Simba implementation
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
