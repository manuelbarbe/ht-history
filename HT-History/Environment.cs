using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges;
using HtHistory.Translation;

namespace HtHistory
{
    static class Environment
    {
        public static IDataBridgeFactory DataBridgeFactory { get; set; }

        //private static ITranslator _translator = new DecoratingTranslator(new NullTranslator(), "%%");
        //public static ITranslator Translator { get { return _translator; } set { _translator = value; } }
    }
}
