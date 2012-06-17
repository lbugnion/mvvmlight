using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace ModifyRegistryKey
{
    class Program
    {
#if LOG
        private static StringBuilder _report = new StringBuilder();
#endif

        private const string InstallActionVs11User = "-i11u";
        private const string InstallActionVs11Machine = "-i11m";
        private const string InstallActionVs10User = "-i10u";
        private const string InstallActionVs10Machine = "-i10m";
        private const string InstallActionVs08User = "-i08u";
        private const string InstallActionVs08Machine = "-i08m";
        private const string InstallActionVs10X = "-i10x";
        private const string InstallActionVs11X = "-i11x";
        private const string UninstallActionUser = "-uu";
        private const string UninstallActionMachine = "-um";

        private const string PersonalFolderVs10SnippetsPath = "Visual Studio 2010\\Code Snippets\\Visual C#";
        private const string PersonalFolderVs11SnippetsPath = "Visual Studio 11\\Code Snippets\\Visual C#";

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

        private static readonly PathInfo SnippetsRegistryPathInfoVs11User = new PathInfo
        {
            RootKey = Registry.CurrentUser,
            KeyPath = @"Software\Microsoft\VisualStudio\11.0\Languages\CodeExpansions\Visual C#",
            KeyName = "path"
        };

        static void Main(string[] args)
        {
#if LOG
            _report.Append("Starting install at ");
            _report.Append(DateTime.Now.ToShortDateString());
            _report.Append(DateTime.Now.ToLongTimeString());
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("001: " + args[0]);
            //Console.ReadLine();

            if (args.Length < 2
                || string.IsNullOrEmpty(args[1])
                || (args[0] != InstallActionVs11User
                    && args[0] != InstallActionVs11Machine
                    && args[0] != InstallActionVs10User
                    && args[0] != InstallActionVs10Machine
                    && args[0] != InstallActionVs08User
                    && args[0] != InstallActionVs08Machine
                    && args[0] != InstallActionVs10X
                    && args[0] != InstallActionVs11X
                    && args[0] != UninstallActionUser
                    && args[0] != UninstallActionMachine))
            {
#if LOG
                _report.Append("Error when installing");
                _report.Append(Environment.NewLine);
                WriteReport();
#endif
                Console.WriteLine("Syntax: ModifyRegistryKey [-i11u|-i11m|-i10u|-i10m|-i10x|-i11x|-i08u|-i08m|-uu|-um] [pathOfSnippetsFolder];[pathOfVsExpress]");
                Console.ReadLine();
                return;
            }

#if LOG
            _report.Append(string.Format("Args[0]: {0}", args[0]));
            _report.Append(Environment.NewLine);
            _report.Append(string.Format("Args[1]: {0}", args[1]));
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("Arg 1: " + args[1]);
            //Console.ReadLine();

            var parsedArgs = args[1].Split(
                new[]
                {
                    ';'
                });

            if (args[0] == InstallActionVs10X)
            {
                RunInstallVs10X(parsedArgs[0]);
            }
            else
            {
                if (args[0] == InstallActionVs11X)
                {
                    RunInstallVs11X(parsedArgs[0]);
                }
                else
                {
                    if (args[0] == UninstallActionUser
                        || args[0] == UninstallActionMachine)
                    {
                        RunUninstall(args[0], parsedArgs[0]);
                    }
                    else
                    {
                        RunInstall(args[0], parsedArgs[0]);
                    }
                }
            }

#if LOG
            _report.Append("Ending install at ");
            _report.Append(DateTime.Now.ToShortDateString());
            _report.Append(DateTime.Now.ToLongTimeString());
            _report.Append(Environment.NewLine);
            WriteReport();
#endif
        }

#if LOG
        private static void WriteReport()
        {
            if (!Directory.Exists("c:\\temp"))
            {
                Directory.CreateDirectory("c:\\temp");
            }

            var appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var logFile = new FileInfo("c:\\temp\\mvvmlightinstall.txt");

            if (logFile.Exists
                && logFile.Length > 5000)
            {
                logFile.Delete();
            }

            using (var stream = File.Open("c:\\temp\\mvvmlightinstall.txt", FileMode.Append))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(_report.ToString());
                }
            }
        }
#endif

        private const string MvvmLightFolderName = "MvvmLight";

        private static void RunUninstallVs10X()
        {
#if LOG
            _report.Append("RunUninstallVs10X");
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("RunUninstallVs10X");
            //Console.ReadLine();

            RunUninstallVs10XVs11X(PersonalFolderVs10SnippetsPath);
        }

        private static void RunUninstallVs11X()
        {
#if LOG
            _report.Append("RunUninstallVs11X");
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("RunUninstallVs11X");
            //Console.ReadLine();

            RunUninstallVs10XVs11X(PersonalFolderVs11SnippetsPath);
        }

        private static void RunUninstallVs10XVs11X(string personalFolderSnippetsPath)
        {
#if LOG
            _report.Append("RunUninstallVs10XVS11X");
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("RunInstallVs10x");
            //Console.ReadLine();

            try
            {
                var personalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var destinationSnippetsRootFolder = Path.Combine(personalFolderPath, personalFolderSnippetsPath);

                if (!Directory.Exists(destinationSnippetsRootFolder))
                {
                    return;
                }

                var allLanguages = Directory.GetDirectories(destinationSnippetsRootFolder);

                foreach (var language in allLanguages)
                {
#if LOG
                    _report.Append("In " + language);
                    _report.Append(Environment.NewLine);
#endif
                    //Console.WriteLine("In " + language);
                    //Console.ReadLine();

                    var mvvmLightFolderPath = Path.Combine(language, MvvmLightFolderName);

                    if (Directory.Exists(mvvmLightFolderPath))
                    {
#if LOG
                        _report.Append("Deleting " + mvvmLightFolderPath);
                        _report.Append(Environment.NewLine);
#endif
                        //Console.WriteLine("Deleting " + mvvmLightFolderPath);
                        //Console.ReadLine();
                        Directory.Delete(mvvmLightFolderPath, true);
                    }
                }
            }
            catch (Exception ex)
            {
#if LOG
                _report.Append("Error when uninstalling snippets for VS Express. Please contact laurent@galasoft.ch. Sorry...");
                _report.Append(ex.Message);
                _report.Append(Environment.NewLine);
#endif
                Console.WriteLine(
                    "Error when uninstalling snippets for VS Express. Please contact laurent@galasoft.ch. Sorry...");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void RunInstallVs10X(string snippetsPath)
        {
#if LOG
            _report.Append("RunInstallVs10X");
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("RunInstallVs10X");
            //Console.ReadLine();

            RunInstallVs10XVs11x(snippetsPath, PersonalFolderVs10SnippetsPath);
        }

        private static void RunInstallVs11X(string snippetsPath)
        {
#if LOG
            _report.Append("RunInstallVs11X");
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("RunInstallVs11X");
            //Console.ReadLine();

            RunInstallVs10XVs11x(snippetsPath, PersonalFolderVs11SnippetsPath);
        }

        private static void RunInstallVs10XVs11x(string snippetsPath, string personalFolderSnippetsPath)
        {
#if LOG
            _report.Append("RunInstallVs10XVs11x");
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("RunInstallVs10XVs11x");
            //Console.ReadLine();

            try
            {
                var personalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var destinationSnippetsRootFolder = Path.Combine(personalFolderPath, personalFolderSnippetsPath);

                if (!Directory.Exists(destinationSnippetsRootFolder))
                {
                    Console.WriteLine("Snippets folder not found. If you have Visual Studio 11 express installed,");
                    Console.WriteLine("you must run it at least once and then re-run this installer.");
                    Console.ReadLine();
                    return;
                }

                var allLanguages = Directory.GetDirectories(destinationSnippetsRootFolder);

                foreach (var language in allLanguages)
                {
                    var languageFolder = new DirectoryInfo(Path.Combine(language, MvvmLightFolderName));

#if LOG
                    _report.Append("In " + languageFolder.FullName);
                    _report.Append(Environment.NewLine);
#endif
                    //Console.WriteLine("In " + languageFolder.FullName);
                    //Console.ReadLine();

                    var sourceSnippetsFolders = Directory.GetDirectories(snippetsPath);

#if LOG
                    _report.Append(string.Format("Found {0} folders in {1}", sourceSnippetsFolders.Length, snippetsPath));
                    _report.Append(Environment.NewLine);
#endif
                    //Console.WriteLine("Found {0} folders in {1}", sourceSnippetsFolders.Length, snippetsPath);
                    //Console.ReadLine();

                    if (!languageFolder.Exists)
                    {
#if LOG
                        _report.Append(string.Format("Creating {0}", languageFolder.FullName));
                        _report.Append(Environment.NewLine);
#endif
                        //Console.WriteLine("Creating {0}", languageFolder.FullName);
                        //Console.ReadLine();
                        languageFolder.Create();
                    }

                    foreach (var sourceSnippetsFolder in sourceSnippetsFolders)
                    {
                        var snippets = Directory.GetFiles(sourceSnippetsFolder, "*.snippet");
#if LOG
                        _report.Append(string.Format("{0} files found in {1}", snippets.Length, snippetsPath));
                        _report.Append(Environment.NewLine);
#endif
                        //Console.WriteLine("{0} files found in {1}", snippets.Length, snippetsPath);
                        //Console.ReadLine();

                        foreach (var snippet in snippets)
                        {
#if LOG
                            _report.Append("Copying " + snippet + " to " + language);
                            _report.Append(Environment.NewLine);
#endif
                            //Console.WriteLine("Copying " + snippet + " to " + language);
                            //Console.ReadLine();

                            var file = new FileInfo(snippet);
                            file.CopyTo(Path.Combine(languageFolder.FullName, file.Name), true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if LOG
                _report.Append("Error when installing snippets for VS Express. Please contact laurent@galasoft.ch. Sorry...");
                _report.Append(Environment.NewLine);
#endif
                Console.WriteLine(
                    "Error when installing snippets for VS Express. Please contact laurent@galasoft.ch. Sorry...");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void RunInstall(string command, string snippetsPath)
        {
            try
            {
#if LOG
                _report.Append("RunInstall");
                _report.Append(Environment.NewLine);
#endif
                //Console.WriteLine("RunInstall");
                //Console.ReadLine();

                PathInfo pathInfo = null;

                switch (command)
                {
                    case InstallActionVs11User:
                        pathInfo = SnippetsRegistryPathInfoVs11User;
                        break;
                    case InstallActionVs11Machine:
                        pathInfo = SnippetsRegistryPathInfoVs11Machine;
                        break;
                    case InstallActionVs10User:
                        pathInfo = SnippetsRegistryPathInfoVs10User;
                        break;
                    case InstallActionVs10Machine:
                        pathInfo = SnippetsRegistryPathInfoVs10Machine;
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
#if LOG
                    _report.Append("New path: " + snippetsPaths + snippetsPath + ";");
                    _report.Append(Environment.NewLine);
#endif
                    //Console.WriteLine("New path: " + snippetsPaths + snippetsPath + ";");
                    //Console.ReadLine();
                    subKey.SetValue(pathInfo.KeyName, snippetsPaths + snippetsPath + ";");
                }
            }
            catch (Exception ex)
            {
#if LOG
                _report.Append("Error when installing snippets. Please contact laurent@galasoft.ch. Sorry...");
                _report.Append(Environment.NewLine);
#endif
                Console.WriteLine(
                    "Error when installing snippets. Please contact laurent@galasoft.ch. Sorry...");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static string GetPath(PathInfo pathInfo, out RegistryKey subKey)
        {
#if LOG
            _report.Append(string.Format(
                "Checking subKey {0} in {1}",
               pathInfo.KeyPath,
               pathInfo.RootKey.Name));
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine(
            //   "Checking subKey {0} in {1}",
            //   pathInfo.KeyPath,
            //   pathInfo.RootKey.Name);
            //Console.ReadLine();

            subKey = pathInfo.RootKey.OpenSubKey(pathInfo.KeyPath, true);

            if (subKey == null)
            {
#if LOG
                _report.Append(string.Format("subKey == null ({0})", pathInfo.KeyPath));
                _report.Append(Environment.NewLine);
#endif
                //Console.WriteLine("subKey == null ({0})", pathInfo.KeyPath);
                //Console.ReadLine();
                return null;
            }

            var path = subKey.GetValue(pathInfo.KeyName);

            if (path == null)
            {
                return null;
            }

#if LOG
            _report.Append("Old path: " + path);
            _report.Append(Environment.NewLine);
#endif
            //Console.WriteLine("Old path: " + path);
            //Console.ReadLine();
            return path.ToString();
        }

        private static void RunUninstall(string command, string snippetsPath)
        {
            try
            {
#if LOG
                _report.Append("RunUninstall");
                _report.Append(Environment.NewLine);
#endif
                //Console.WriteLine("RunUninstall");
                //Console.ReadLine();

                var allPathsInfo = new List<PathInfo>();

                switch (command)
                {
                    case UninstallActionUser:
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs08User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs10User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs11User);
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
#if LOG
                    _report.Append(string.Format("Checking {0}", info.KeyName));
                    _report.Append(Environment.NewLine);
#endif
                    //Console.WriteLine("Checking {0}", info.KeyName);
                    //Console.ReadLine();

                    RegistryKey subKey;
                    var snippetsPaths = GetPath(info, out subKey);

                    if (string.IsNullOrEmpty(snippetsPaths)
                        || subKey == null)
                    {
#if LOG
                        _report.Append("Null");
                        _report.Append(Environment.NewLine);
#endif
                        //Console.WriteLine("Null");
                        //Console.ReadLine();
                        continue;
                    }

                    if (snippetsPaths.Contains(snippetsPath))
                    {
                        snippetsPaths = snippetsPaths.Replace(snippetsPath, "");
#if LOG
                        _report.Append("New path: " + snippetsPaths);
                        _report.Append(Environment.NewLine);
#endif
                        //Console.WriteLine("New path: " + snippetsPaths);
                        //Console.ReadLine();
                        subKey.SetValue(info.KeyName, snippetsPaths);
                    }
                }

                if (command == UninstallActionUser)
                {
                    RunUninstallVs10X();
                    RunUninstallVs11X();
                }
            }
            catch (Exception ex)
            {
#if LOG
                _report.Append("Error when installing snippets. Please contact laurent@galasoft.ch. Sorry...");
                _report.Append(Environment.NewLine);
#endif
                Console.WriteLine(
                    "Error when installing snippets. Please contact laurent@galasoft.ch. Sorry...");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
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
