using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ModifyRegistryKey
{
    // This installs a registry key to register the snippets folder with Visual Studio.
    class Program
    {
        private const string LogPath = "c:\\temp\\mvvmlightlog.txt";

        private const string InstallActionVs11User = "-i11u";
        private const string InstallActionVs11Machine = "-i11m";
        private const string InstallActionVswinx11 = "-i11vswinx";
        private const string InstallActionVs10User = "-i10u";
        private const string InstallActionVs10Machine = "-i10m";
        private const string InstallActionVs08User = "-i08u";
        private const string InstallActionVs08Machine = "-i08m";
        private const string InstallActionVwd10X = "-i10vwdx";
        private const string InstallActionVpd10X = "-i10vpdx";
        private const string InstallActionVcs10X = "-i10vcsx";
        private const string UninstallActionUser = "-uu";
        private const string UninstallActionMachine = "-um";

        private static readonly PathInfo SnippetsRegistryPathInfoVs08Machine = new PathInfo
        {
            RootKey = Registry.LocalMachine,
            KeyPath = @"Software\Microsoft\VisualStudio\9.0\Languages\CodeExpansions\CSharp\Paths",
            KeyName = "Microsoft Visual CSharp"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVs10Machine = new PathInfo
        {
            RootKey = Registry.LocalMachine,
            KeyPath = @"Software\Microsoft\VisualStudio\10.0\Languages\CodeExpansions\CSharp\Paths",
            KeyName = "Microsoft Visual CSharp"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVs11Machine = new PathInfo
        {
            RootKey = Registry.LocalMachine,
            KeyPath = @"Software\Microsoft\VisualStudio\11.0\Languages\CodeExpansions\CSharp\Paths",
            KeyName = "Microsoft Visual CSharp"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVs08User = new PathInfo
        {
            RootKey = Registry.CurrentUser,
            KeyPath = @"Software\Microsoft\VisualStudio\9.0\Languages\CodeExpansions\csharp",
            KeyName = "path"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVs10User = new PathInfo
        {
            RootKey = Registry.CurrentUser,
            KeyPath = @"Software\Microsoft\VisualStudio\10.0\Languages\CodeExpansions\csharp",
            KeyName = "path"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVwdx10User = new PathInfo
        {
            RootKey = Registry.CurrentUser,
            KeyPath = @"Software\Microsoft\VWDExpress\10.0\Languages\CodeExpansions\Visual C#",
            KeyName = "Path"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVpdx10User = new PathInfo
        {
            RootKey = Registry.CurrentUser,
            KeyPath = @"Software\Microsoft\VPDExpress\10.0\Languages\CodeExpansions\Visual C#",
            KeyName = "Path"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVcsx10User = new PathInfo
        {
            RootKey = Registry.CurrentUser,
            KeyPath = @"Software\Microsoft\VCSExpress\10.0\Languages\CodeExpansions\Visual C#",
            KeyName = "Path"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVs11User = new PathInfo
        {
            RootKey = Registry.CurrentUser,
            KeyPath = @"Software\Microsoft\VisualStudio\11.0\Languages\CodeExpansions\Visual C#",
            KeyName = "Path"
        };

        private static readonly PathInfo SnippetsRegistryPathInfoVswinx11User = new PathInfo
        {
            RootKey = Registry.CurrentUser,
            KeyPath = @"Software\Microsoft\VSWINExpress\11.0\Languages\CodeExpansions\Visual C#",
            KeyName = "Path"
        };

        static void Main(string[] args)
        {
            Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ":" + args[0]);

            if (args.Length < 2
                || string.IsNullOrEmpty(args[1])
                || (args[0] != InstallActionVs11User
                    && args[0] != InstallActionVs11Machine
                    && args[0] != InstallActionVs10User
                    && args[0] != InstallActionVs10Machine
                    && args[0] != InstallActionVs08User
                    && args[0] != InstallActionVs08Machine
                    && args[0] != InstallActionVcs10X
                    && args[0] != InstallActionVpd10X
                    && args[0] != InstallActionVwd10X
                    && args[0] != InstallActionVswinx11
                    && args[0] != UninstallActionUser
                    && args[0] != UninstallActionMachine))
            {
                Log("Syntax: ModifyRegistryKey [-i11u|-i11m|-i11vswinx|-i10u|-i10m|-i10vcsx|-i10vpdx|-i10vwdx|-i08u|-i08m|-uu|-um] [pathOfSnippetsFolder]");
                return;
            }

            Log("Arg 1: " + args[1]);
            
            if (args[0] == UninstallActionUser
                || args[0] == UninstallActionMachine)
            {
                RunUninstall(args[0], args[1]);
            }
            else
            {
                RunInstall(args[0], args[1]);
            }
        }

        //private const string MvvmLightFolderName = "MvvmLight";

        //private static void RunUninstallVs10X()
        //{
        //    Log("RunInstallVs10x");
            
        //    try
        //    {
        //        var personalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //        var destinationSnippetsRootFolder = Path.Combine(personalFolderPath, PersonalFolderVs10SnippetsPath);

        //        var allLanguages = Directory.GetDirectories(destinationSnippetsRootFolder);

        //        foreach (var language in allLanguages)
        //        {
        //            Log("In " + language);
                   
        //            var mvvmLightFolderPath = Path.Combine(language, MvvmLightFolderName);

        //            if (Directory.Exists(mvvmLightFolderPath))
        //            {
        //                Log("Deleting " + mvvmLightFolderPath);
        //                Directory.Delete(mvvmLightFolderPath, true);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log("Error when uninstalling snippets for VS10 Express. Please contact laurent@galasoft.ch. Sorry...");
        //        Log(ex.Message);
        //    }
        //}

        //private static void RunInstallVs10X(string snippetsPath)
        //{
        //    Log("RunInstallVs10x");
            
        //    try
        //    {
        //        var personalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //        var destinationSnippetsRootFolder = Path.Combine(personalFolderPath, PersonalFolderVs10SnippetsPath);

        //        var allLanguages = Directory.GetDirectories(destinationSnippetsRootFolder);

        //        foreach (var language in allLanguages)
        //        {
        //            var languageFolder = new DirectoryInfo(Path.Combine(language, MvvmLightFolderName));

        //            Log("In " + languageFolder.FullName);
                    
        //            var sourceSnippetsFolders = Directory.GetDirectories(snippetsPath);

        //            Log(string.Format("Found {0} folders in {1}", sourceSnippetsFolders.Length, snippetsPath));
                    
        //            if (!languageFolder.Exists)
        //            {
        //                Log(string.Format("Creating {0}", languageFolder.FullName));
        //                languageFolder.Create();
        //            }

        //            foreach (var sourceSnippetsFolder in sourceSnippetsFolders)
        //            {
        //                var snippets = Directory.GetFiles(sourceSnippetsFolder, "*.snippet");
        //                Log(string.Format("{0} files found in {1}", snippets.Length, snippetsPath));
                        
        //                foreach (var snippet in snippets)
        //                {
        //                    Log("Copying " + snippet + " to " + language);
                            
        //                    var file = new FileInfo(snippet);
        //                    file.CopyTo(Path.Combine(languageFolder.FullName, file.Name), true);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log("Error when installing snippets for VS10 Express. Please contact laurent@galasoft.ch. Sorry...");
        //        Log(ex.Message);
        //    }
        //}

        private static void RunInstall(string command, string snippetsPath)
        {
            try
            {
                Log("RunInstall");
                
                PathInfo pathInfo = null;

                switch (command)
                {
                    case InstallActionVs11User:
                        pathInfo = SnippetsRegistryPathInfoVs11User;
                        break;
                    case InstallActionVs11Machine:
                        pathInfo = SnippetsRegistryPathInfoVs11Machine;
                        break;
                    case InstallActionVswinx11:
                        pathInfo = SnippetsRegistryPathInfoVswinx11User;
                        break;
                    case InstallActionVs10User:
                        pathInfo = SnippetsRegistryPathInfoVs10User;
                        break;
                    case InstallActionVs10Machine:
                        pathInfo = SnippetsRegistryPathInfoVs10Machine;
                        break;
                    case InstallActionVcs10X:
                        pathInfo = SnippetsRegistryPathInfoVcsx10User;
                        break;
                    case InstallActionVpd10X:
                        pathInfo = SnippetsRegistryPathInfoVpdx10User;
                        break;
                    case InstallActionVwd10X:
                        pathInfo = SnippetsRegistryPathInfoVwdx10User;
                        break;
                    case InstallActionVs08User:
                        pathInfo = SnippetsRegistryPathInfoVs08User;
                        break;
                    case InstallActionVs08Machine:
                        pathInfo = SnippetsRegistryPathInfoVs08Machine;
                        break;
                }

                if (pathInfo == null)
                {
                    return;
                }

                RegistryKey subKey;
                var snippetsPaths = GetPath(pathInfo, out subKey);

                if (string.IsNullOrEmpty(snippetsPaths)
                    || subKey == null)
                {
                    return;
                }

                if (!snippetsPaths.EndsWith(";"))
                {
                    snippetsPaths = snippetsPaths + ";";
                }

                if (!snippetsPaths.Contains(snippetsPath))
                {
                    Log("New path: " + snippetsPaths + snippetsPath + ";");
                    subKey.SetValue(pathInfo.KeyName, snippetsPaths + snippetsPath + ";");
                }
            }
            catch (Exception ex)
            {
                Log("Error when installing snippets. Please contact laurent@galasoft.ch. Sorry...");
                Log(ex.Message);
            }
        }

        private static string GetPath(PathInfo pathInfo, out RegistryKey subKey)
        {
            Log(string.Format("Checking subKey {0} in {1}",
               pathInfo.KeyPath,
               pathInfo.RootKey.Name));
            
            subKey = pathInfo.RootKey.OpenSubKey(pathInfo.KeyPath, true);

            if (subKey == null)
            {
                Log(string.Format("subKey == null ({0})", pathInfo.KeyPath));
                return null;
            }

            var path = subKey.GetValue(pathInfo.KeyName);

            if (path == null)
            {
                return null;
            }

            Log("Old path: " + path);
            return path.ToString();
        }

        private static void RunUninstall(string command, string snippetsPath)
        {
            try
            {
                Log("RunUninstall");
                
                var allPathsInfo = new List<PathInfo>();

                switch (command)
                {
                    case UninstallActionUser:
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs08User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs10User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVcsx10User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVpdx10User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVwdx10User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs11User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVswinx11User);
                        break;
                    case UninstallActionMachine:
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs08Machine);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs10Machine);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs11Machine);
                        break;
                }

                snippetsPath = snippetsPath + ";";

                foreach (var info in allPathsInfo)
                {
                    Log(string.Format("Checking {0}", info.KeyName));
                    
                    RegistryKey subKey;
                    var snippetsPaths = GetPath(info, out subKey);

                    if (string.IsNullOrEmpty(snippetsPaths)
                        || subKey == null)
                    {
                        Log("Null");
                        continue;
                    }

                    if (snippetsPaths.Contains(snippetsPath))
                    {
                        snippetsPaths = snippetsPaths.Replace(snippetsPath, "");
                        Log("New path: " + snippetsPaths);
                        subKey.SetValue(info.KeyName, snippetsPaths);
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Error when installing snippets. Please contact laurent@galasoft.ch. Sorry...");
                Log(ex.Message);
            }
        }

        private static void Log(string message)
        {
            using (var stream = File.Open(LogPath, FileMode.Append))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine(DateTime.Now.ToLongTimeString());
                    writer.WriteLine(message);
                    writer.WriteLine();
                }
            }
        }
    }

    internal class PathInfo
    {
        public RegistryKey RootKey
        {
            get;
            set;
        }

        public string KeyPath
        {
            get;
            set;
        }

        public string KeyName
        {
            get;
            set;
        }
    }
}
