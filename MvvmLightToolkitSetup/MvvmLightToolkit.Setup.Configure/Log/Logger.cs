// ****************************************************************************
// <copyright file="Logger.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>28.6.2009</date>
// <project>MvvmLightToolkit.Setup.Configure</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using MvvmLightToolkit.Setup.Configure.Helpers;

namespace MvvmLightToolkit.Setup.Configure.Log
{
    /// <summary>
    /// Logs messages to a local log file.
    /// </summary>
    public class Logger
    {
        private const string LogFileName = "setup.log";

        private readonly FileInfo _logFile;

        private bool _continueLogging = true;

        /// <summary>
        /// Initializes a new instance of the Logger class.
        /// </summary>
        public Logger()
        {
            _logFile = new FileInfo(Path.Combine(
                                        SettingsFileHandler.AppDataFolder.FullName,
                                        LogFileName));
        }

        /// <summary>
        /// Logs a message to the log file. If an error occurs while logging,
        /// it will be suspended for the rest of the application's lifetime.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "This is just a failsafe")]
        public void Log(string message)
        {
            if (_continueLogging)
            {
                try
                {
                    using (var writer = new StreamWriter(_logFile.FullName, true))
                    {
                        var now = DateTime.Now;

                        writer.Write(now.ToShortDateString());
                        writer.Write(" ");
                        writer.WriteLine(now.ToLongTimeString());
                        writer.WriteLine(message);
                    }
                }
                catch
                {
                    _continueLogging = false;
                }
            }
        }

        /// <summary>
        /// Logs an exception and all its inner exceptions.
        /// </summary>
        /// <param name="message">An initial message.</param>
        /// <param name="ex">The exception to log.</param>
        public void Log(string message, Exception ex)
        {
            var msg = message + Environment.NewLine
                      + ex.Message;
            var innerEx = ex.InnerException;

            while (innerEx != null)
            {
                msg += innerEx.Message
                       + Environment.NewLine;

                innerEx = innerEx.InnerException;
            }

            Log(msg);
        }

        /// <summary>
        /// Logs the result of a method.
        /// </summary>
        /// <param name="message">An initial message.</param>
        /// <param name="method">The method to execute. It must return
        /// a string!</param>
        public void Log(string message, Func<string> method)
        {
            var result = method();
            Log(message + Environment.NewLine + result);
        }
    }
}