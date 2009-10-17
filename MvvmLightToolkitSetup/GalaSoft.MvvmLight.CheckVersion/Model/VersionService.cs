// ****************************************************************************
// <copyright file="VersionService.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>12.9.2009</date>
// <project>GalaSoft.MvvmLight.CheckVersion</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using GalaSoft.MvvmLight.CheckVersion.Properties;
using MvvmLightToolkit.Setup.Configure.Helpers;

namespace GalaSoft.MvvmLight.CheckVersion.Model
{
    public class VersionService : IVersionService, IDisposable
    {
        private WebClient _client;

        public VersionService()
        {
            _client = new WebClient();
            _client.DownloadStringCompleted += ClientDownloadStringCompleted;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void GetVersionOnClient(Action<Version> callback)
        {
            if (callback == null)
            {
                return;
            }

            var fileHandler = new SettingsFileHandler();
            var version = new Version(fileHandler.SavedSettings.InstalledVersion);

            callback(version);
        }

        public void GetVersionOnServer(Action<Version> callback)
        {
            if (callback == null)
            {
                return;
            }

            var uri = new Uri(Settings.Default.VersionFileLocation);
            _client.DownloadStringAsync(uri, callback);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _client.Dispose();
                _client = null;
            }
        }

        private static void ClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var callback = e.UserState as Action<Version>;
            if (callback == null)
            {
                return;
            }

            if (e.Error != null)
            {
                callback(null);
            }

            var result = e.Result;
            if (result.StartsWith("ï»¿", StringComparison.Ordinal))
            {
                result = result.Substring(3);
            }

            try
            {
                var document = XDocument.Load(new StringReader(result));
                var versionString = from v
                                        in document.Descendants("version")
                                    select v;

                var version = new Version(versionString.First().Value);
                callback(version);
            }
            catch (XmlException)
            {
                callback(null);
            }
        }
    }
}