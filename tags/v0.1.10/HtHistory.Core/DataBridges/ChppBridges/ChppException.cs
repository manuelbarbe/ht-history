using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    public class ChppException : Exception
    {
        public int ErrorCode { get; private set; }
        public string ErrorDescription { get; private set; }

        public ChppException(int errorCode, string errorDescription)
        {
            if (errorDescription == null) throw new ArgumentNullException("errorDescription");

            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        public override string ToString()
        {
            return string.Format("CHPP error: {0} ({1})", ErrorDescription, ErrorCode);
        }

    }
}
