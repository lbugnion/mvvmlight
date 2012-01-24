using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ModifyRegistryKey
{
    class Program
    {
        private const string InstallActionVs10User = "-i10u";
        private const string InstallActionVs10Machine = "-i10m";
        private const string InstallActionVs08User = "-i08u";
        private const string InstallActionVs08Machine = "-i08m";
        private const string InstallActionVs10X = "-i10x";
        private const string UninstallActionUser = "-uu";
        private const string UninstallActionMachine = "-um";

        private const string PersonalFolderSnippetsPath = "Visual Studio 2010\\Code Snippets\\Visual C#";

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

        static void Main(string[] args)
        {
            // Console.WriteLine("008: " + args[0]);
            // Console.ReadLine();

            if (args.Length < 2
                || string.IsNullOrEmpty(args[1])
                || (args[0] != InstallActionVs10User
                    && args[0] != InstallActionVs10Machine
                    && args[0] != InstallActionVs08User
                    && args[0] != InstallActionVs08Machine
                    && args[0] != InstallActionVs10X
                    && args[0] != UninstallActionUser
                    && args[0] != UninstallActionMachine))
            {
                Console.WriteLine("Syntax: ModifyRegistryKey [-i10u|-i10m|-i10x|-i08u|-i08m|-uu|-um] [pathOfSnippetsFolder];[pathOfVs10Express]");
                Console.ReadLine();
                return;
            }

            // Console.WriteLine("Arg 1: " + args[1]);
            // Console.ReadLine();

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

        private const string MvvmLightFolderName = "MvvmLight";

        private static void RunUninstallVs10X()
        {
            // Console.WriteLine("RunInstallVs10x");
            // Console.ReadLine();

            try
            {
                var personalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var destinationSnippetsRootFolder = Path.Combine(personalFolderPath, PersonalFolderSnippetsPath);

                var allLanguages = Directory.GetDirectories(destinationSnippetsRootFolder);

                foreach (var language in allLanguages)
                {
                    // Console.WriteLine("In " + language);
                    // Console.ReadLine();

                    var mvvmLightFolderPath = Path.Combine(language, MvvmLightFolderName);

                    if (Directory.Exists(mvvmLightFolderPath))
                    {
                        // Console.WriteLine("Deleting " + mvvmLightFolderPath);
                        // Console.ReadLine();
                        Directory.Delete(mvvmLightFolderPath, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error when uninstalling snippets for VS10 Express. Please contact laurent@galasoft.ch. Sorry...");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void RunInstallVs10X(string snippetsPath)
        {
            // Console.WriteLine("RunInstallVs10x");
            // Console.ReadLine();

            try
            {
                var personalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var destinationSnippetsRootFolder = Path.Combine(personalFolderPath, PersonalFolderSnippetsPath);

                var allLanguages = Directory.GetDirectories(destinationSnippetsRootFolder);

                foreach (var language in allLanguages)
                {
                    var languageFolder = new DirectoryInfo(Path.Combine(language, MvvmLightFolderName));

                    // Console.WriteLine("In " + languageFolder.FullName);
                    // Console.ReadLine();

                    var sourceSnippetsFolders = Directory.GetDirectories(snippetsPath);

                    // Console.WriteLine("Found {0} folders in {1}", sourceSnippetsFolders.Length, snippetsPath);
                    // Console.ReadLine();

                    if (!languageFolder.Exists)
                    {
                        // Console.WriteLine("Creating {0}", languageFolder.FullName);
                        // Console.ReadLine();
                        languageFolder.Create();
                    }

                    foreach (var sourceSnippetsFolder in sourceSnippetsFolders)
                    {
                        var snippets = Directory.GetFiles(sourceSnippetsFolder, "*.snippet");
                        // Console.WriteLine("{0} files found in {1}", snippets.Length, snippetsPath);
                        // Console.ReadLine();

                        foreach (var snippet in snippets)
                        {
                            // Console.WriteLine("Copying " + snippet + " to " + language);
                            // Console.ReadLine();

                            var file = new FileInfo(snippet);
                            file.CopyTo(Path.Combine(languageFolder.FullName, file.Name), true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error when installing snippets for VS10 Express. Please contact laurent@galasoft.ch. Sorry...");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void RunInstall(string command, string snippetsPath)
        {
            try
            {
                // Console.WriteLine("RunInstall");
                // Console.ReadLine();

                PathInfo pathInfo = null;

                switch (command)
                {
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
                    // Console.WriteLine("New path: " + snippetsPaths + snippetsPath + ";");
                    // Console.ReadLine();
                    subKey.SetValue(pathInfo.KeyName, snippetsPaths + snippetsPath + ";");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error when installing snippets. Please contact laurent@galasoft.ch. Sorry...");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static string GetPath(PathInfo pathInfo, out RegistryKey subKey)
        {
            // Console.WriteLine(
                //"Checking subKey {0} in {1}", 
                //pathInfo.KeyPath,
                //pathInfo.RootKey.Name);
            // Console.ReadLine();

            subKey = pathInfo.RootKey.OpenSubKey(pathInfo.KeyPath, true);

            if (subKey == null)
            {
                // Console.WriteLine("subKey == null ({0})", pathInfo.KeyPath);
                // Console.ReadLine();
                return null;
            }

            var path = subKey.GetValue(pathInfo.KeyName);

            if (path == null)
            {
                return null;
            }

            // Console.WriteLine("Old path: " + path);
            // Console.ReadLine();
            return path.ToString();
        }

        private static void RunUninstall(string command, string snippetsPath)
        {
            try
            {
                // Console.WriteLine("RunUninstall");
                // Console.ReadLine();

                var allPathsInfo = new List<PathInfo>();

                switch (command)
                {
                    case UninstallActionUser:
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs08User);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs10User);
                        break;
                    case UninstallActionMachine:
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs08Machine);
                        allPathsInfo.Add(SnippetsRegistryPathInfoVs10Machine);
                        break;
                }

                snippetsPath = snippetsPath + ";";

                foreach (var info in allPathsInfo)
                {
                    // Console.WriteLine("Checking {0}", info.KeyName);
                    // Console.ReadLine();

                    RegistryKey subKey;
                    var snippetsPaths = GetPath(info, out subKey);

                    if (string.IsNullOrEmpty(snippetsPaths)
                        || subKey == null)
                    {
                        // Console.WriteLine("Null");
                        // Console.ReadLine();
                        continue;
                    }

                    if (snippetsPaths.Contains(snippetsPath))
                    {
                        snippetsPaths = snippetsPaths.Replace(snippetsPath, "");
                        // Console.WriteLine("New path: " + snippetsPaths);
                        // Console.ReadLine();
                        subKey.SetValue(info.KeyName, snippetsPaths);
                    }
                }

                if (command == UninstallActionUser)
                {
                    RunUninstallVs10X();
                }
            }
            catch (Exception ex)
            {
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
