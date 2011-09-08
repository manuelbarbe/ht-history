using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core
{
    public static class HtLog
    {
        public enum Level
        {
            Trace = 0,
            Debug = 10,
            Info = 20,
            Warn = 30,
            Error = 40,
            Fatal = 50
        }

        public delegate void LogAppender(DateTime time, HtLog.Level level, string message); 
        public static LogAppender Appenders;

        public static void Log(Level level, string format, params object[] objs)
        {
            try
            {
                if (Appenders != null)
                {
                    Appenders(DateTime.Now, level, String.Format(format, objs));
                }
            }
            catch (Exception ex)
            {
                // suppress
            }
        }

        public static void Trace(string format, params object[] objs)
        {
            Log(Level.Trace, format, objs);
        }

        public static void Debug(string format, params object[] objs)
        {
            Log(Level.Trace, format, objs);
        }

        public static void Info(string format, params object[] objs)
        {
            Log(Level.Trace, format, objs);
        }

        public static void Warn(string format, params object[] objs)
        {
            Log(Level.Trace, format, objs);
        }

        public static void Error(string format, params object[] objs)
        {
            Log(Level.Trace, format, objs);
        }

        public static void Fatal(string format, params object[] objs)
        {
            Log(Level.Trace, format, objs);
        }
    }
}
