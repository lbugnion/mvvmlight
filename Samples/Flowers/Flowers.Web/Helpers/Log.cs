using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Flowers.Helpers
{
    public static class Log
    {
        private const string LogPath = "log.txt";
        private const string LogEntryMask = "{0:yyyymmddhhMMss} {1}";

        public static HttpContext Context
        {
            get;
            internal set;
        }

        public static void LogEntry(string message, HttpContext context = null)
        {
            var mustLog = ConfigurationManager.AppSettings["MustLog"];

            if (mustLog != "True")
            {
                return;
            }

            if (Context == null)
            {
                Context = context;
            }

            if (Context == null)
            {
                throw new ArgumentNullException("context");
            }

            using (var stream = File.Open(Context.Request.MapPath(LogPath), FileMode.Append))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine(LogEntryMask, DateTime.Now, message);
                }
            }
        }

        public static bool ClearLog()
        {
            try
            {
                File.Delete(Context.Request.MapPath(LogPath));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}