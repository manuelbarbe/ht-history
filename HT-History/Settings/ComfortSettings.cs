using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory
{
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


    }
}
