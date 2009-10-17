// ****************************************************************************
// <copyright file="Installer.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>26.6.2009</date>
// <project>MvvmLightToolkit.Setup.Configure</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip;
using MvvmLightToolkit.Setup.Configure.Properties;
using MvvmLightToolkit.Setup.Configure.ViewModel;

namespace MvvmLightToolkit.Setup.Configure.Helpers
{
    /// <summary>
    /// The class performing the actual installation.
    /// </summary>
    internal class Installer
    {
        private const string BinariesPathSl = "Binaries{0}Silverlight";

        private const string BinariesPathWpf = "Binaries";

        private const string DllName = "GalaSoft.MvvmLight.dll";

        private const string ItemTemplatesBlendTargetSubPathSl = "ItemTemplates{0}CSharp{0}Silverlight";

        private const string ItemTemplatesBlendTargetSubPathWpf = "ItemTemplates{0}CSharp{0}WPF";

        private const string ItemTemplatesSourcePathSl = "Templates{0}ItemTemplates{0}Silverlight{0}Mvvm";

        private const string ItemTemplatesSourcePathWpf = "Templates{0}ItemTemplates{0}WPF{0}Mvvm";

        private const string OldItemsTemplatesSubPathWpf = @"ItemTemplates{0}Visual C#{0}Mvvm";

        private const string OldProjectTemplatesSubPathWpf = @"ProjectTemplates{0}Visual C#{0}Mvvm";

        private const string PlaceholderLine = "REPLACE_HERE";

        private const string ProjectFileModelPathSl = "Models{0}ProjectFile.csproj.sl.txt";

        private const string ProjectFileModelPathWpf = "Models{0}ProjectFile.csproj.wpf.txt";

        private const string ProjectFileNameSl = "ProjectForTemplateSL.csproj";

        private const string ProjectFileNameWpf = "ProjectForTemplate.csproj";

        private const string ProjectTemplatesBlendTargetSubPathSl = "ProjectTemplates{0}CSharp{0}Silverlight";

        private const string ProjectTemplatesBlendTargetSubPathWpf = "ProjectTemplates{0}CSharp{0}WPF";

        private const string ProjectTemplatesSourcePathSl = "Templates{0}ProjectTemplates{0}Silverlight{0}Mvvm";

        private const string ProjectTemplatesSourcePathWpf = "Templates{0}ProjectTemplates{0}WPF{0}Mvvm";

        /* Old stuff to remove */

        private const string ProjectZipFileName = "MvvmLight.zip";

        private const string ReplacementLine1 =
            "<Reference Include=\"{0}, Version={1}, Culture=neutral, PublicKeyToken=3e875cdb3903c512, processorArchitecture=MSIL\">";

        private const string ReplacementLine2 = "<SpecificVersion>False</SpecificVersion>";

        private const string ReplacementLine3 = "<HintPath>{0}</HintPath>";

        private const string ReplacementLine4 = "</Reference>";

        private const string SnippetsSourcePath = "Snippets";

        private const string SnippetsSourcePathSl = "Snippets{0}SL";

        private const string SnippetsSourcePathWpf = "Snippets{0}WPF";

        private static List<FileInfo> _listOfFiles;

        private DirectoryInfo _appDataFolder;

        private DirectoryInfo _blendTemplatesFolder;

        private DirectoryInfo _folderToZip;

        private DirectoryInfo _resourcesFolder;

        /// <summary>
        /// Initializes a new instance of the Installer class.
        /// </summary>
        public Installer()
        {
            MainWindow.Logger.Log("Initializing installer");

            Initialize();
            BuildListOfFiles();
        }

        public static string Format(string subPath)
        {
            return string.Format(CultureInfo.CurrentCulture, subPath, Path.DirectorySeparatorChar);
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Needed for binding")]
        internal void Install(Action<Exception> afterInstall)
        {
            MainWindow.Logger.Log("Enter Install");

            ThreadPool.QueueUserWorkItem(o =>
            {
                Exception ex = null;

                try
                {
                    var settings = ViewModelLocator.SettingsStatic;

                    CleanupOldFolder(settings, OldProjectTemplatesSubPathWpf);
                    CleanupOldFolder(settings, OldItemsTemplatesSubPathWpf);

                    MainWindow.Logger.Log("Executing Install");
                    CreateFolders(settings.InstallType);

                    if (settings.InstallType == InstallType.WpfOnly
                        || settings.InstallType == InstallType.WpfAndSilverlight)
                    {
                        MakeProjectZipTargetFile(settings, InstallType.WpfOnly);
                        UnzipItemTemplatesToBlend(InstallType.WpfOnly);
                        CopyToDestination(settings.ItemTemplatesFolderWpf, ItemTemplatesSourcePathWpf);
                        UnzipProjectTemplateToBlend(InstallType.WpfOnly);
                        EditProjectFile(InstallType.WpfOnly);
                        ZipAndCopyProjectTemplateToStudio(InstallType.WpfOnly);
                        CopyToDestination(settings.SnippetsFolder, SnippetsSourcePathWpf);
                    }

                    if (settings.InstallType == InstallType.SilverlightOnly
                        || settings.InstallType == InstallType.WpfAndSilverlight)
                    {
                        MakeProjectZipTargetFile(settings, InstallType.SilverlightOnly);
                        UnzipItemTemplatesToBlend(InstallType.SilverlightOnly);
                        CopyToDestination(settings.ItemTemplatesFolderSl, ItemTemplatesSourcePathSl);
                        UnzipProjectTemplateToBlend(InstallType.SilverlightOnly);
                        EditProjectFile(InstallType.SilverlightOnly);
                        ZipAndCopyProjectTemplateToStudio(InstallType.SilverlightOnly);
                        CopyToDestination(settings.SnippetsFolder, SnippetsSourcePathSl);
                    }

                    CopyToDestination(settings.SnippetsFolder, SnippetsSourcePath);

                    MainWindow.Logger.Log("Finishing Install");
                }
                catch (Exception ex2)
                {
                    MainWindow.Logger.Log("Exception in Installer.Install: ", ex2);
                    ex = ex2;
                }
                finally
                {
                    if (afterInstall != null)
                    {
                        afterInstall(ex);
                    }
                }
            });

            MainWindow.Logger.Log("Exit Install");
        }

        [SuppressMessage(
            "Microsoft.Design", 
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Catching exception to pass to main View.")]
        internal void Uninstall(Action<Exception> afterUninstall, bool preserveAppData, SettingsViewModel settings)
        {
            var worker = new Thread(() =>
            {
                MainWindow.Logger.Log("Starting Uninstall thread");

                Exception ex = null;

                try
                {
                    MainWindow.Logger.Log("In try block");

                    MakeProjectZipTargetFile(settings, InstallType.WpfOnly);
                    MakeProjectZipTargetFile(settings, InstallType.SilverlightOnly);

                    Uninstall(settings.ItemTemplatesFolderWpf);
                    Uninstall(settings.ItemTemplatesFolderSl);
                    Uninstall(settings.ProjectTemplatesFolderWpf);
                    Uninstall(settings.ProjectTemplatesFolderSl);
                    Uninstall(settings.SnippetsFolder);

                    //// TODO Rework in next version, this is ugly

                    DeleteBlendSubFolder("ProjectTemplates{0}CSharp{0}WPF{0}MvvmLight");
                    DeleteBlendSubFolder("ProjectTemplates{0}CSharp{0}Silverlight{0}MvvmLight");
                    DeleteBlendSubFolder("ItemTemplates{0}CSharp{0}WPF{0}MvvmView");
                    DeleteBlendSubFolder("ItemTemplates{0}CSharp{0}WPF{0}MvvmViewModel");
                    DeleteBlendSubFolder("ItemTemplates{0}CSharp{0}WPF{0}MvvmViewModelLocator");
                    DeleteBlendSubFolder("ItemTemplates{0}CSharp{0}Silverlight{0}MvvmView");
                    DeleteBlendSubFolder("ItemTemplates{0}CSharp{0}Silverlight{0}MvvmViewModel");
                    DeleteBlendSubFolder("ItemTemplates{0}CSharp{0}Silverlight{0}MvvmViewModelLocator");

                    if (this._appDataFolder != null
                        && !preserveAppData)
                    {
                        Directory.Delete(this._appDataFolder.FullName, true);
                    }
                }
                catch (Exception ex2)
                {
                    MainWindow.Logger.Log("Exception in Installer.Uninstall: ", ex2);
                    ex = ex2;
                }
                finally
                {
                    if (afterUninstall != null)
                    {
                        afterUninstall(ex);
                    }
                }
            });

            worker.Start();
            worker.Join();
        }

        private static void CreateFolders(InstallType installType)
        {
            var vm = ViewModelLocator.SettingsStatic;

            if (installType == InstallType.WpfAndSilverlight
                || installType == InstallType.WpfOnly)
            {
                if (!Directory.Exists(vm.ProjectTemplatesFolderWpf.FullName))
                {
                    MainWindow.Logger.Log("Create " + vm.ProjectTemplatesFolderWpf.FullName);
                    Directory.CreateDirectory(vm.ProjectTemplatesFolderWpf.FullName);
                }

                if (!Directory.Exists(vm.ItemTemplatesFolderWpf.FullName))
                {
                    MainWindow.Logger.Log("Create " + vm.ItemTemplatesFolderWpf.FullName);
                    Directory.CreateDirectory(vm.ItemTemplatesFolderWpf.FullName);
                }
            }

            if (installType == InstallType.WpfAndSilverlight
                || installType == InstallType.SilverlightOnly)
            {
                if (!Directory.Exists(vm.ProjectTemplatesFolderSl.FullName))
                {
                    MainWindow.Logger.Log("Create " + vm.ProjectTemplatesFolderSl.FullName);
                    Directory.CreateDirectory(vm.ProjectTemplatesFolderSl.FullName);
                }

                if (!Directory.Exists(vm.ItemTemplatesFolderSl.FullName))
                {
                    MainWindow.Logger.Log("Create " + vm.ItemTemplatesFolderSl.FullName);
                    Directory.CreateDirectory(vm.ItemTemplatesFolderSl.FullName);
                }
            }

            if (!Directory.Exists(vm.SnippetsFolder.FullName))
            {
                MainWindow.Logger.Log("Create " + vm.SnippetsFolder.FullName);
                Directory.CreateDirectory(vm.SnippetsFolder.FullName);
            }
        }

        private static void DeleteBlendSubFolder(string folderPath)
        {
            var blendFolder = SettingsFileHandler.BlendDocumentsFolder;

            folderPath = Path.Combine(blendFolder.FullName, Format(folderPath));
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }

        private static void Uninstall(DirectoryInfo folder)
        {
            if (folder != null
                && Directory.Exists(folder.FullName))
            {
                MainWindow.Logger.Log("Uninstall folder " + folder.FullName);

                var filesInDestination = folder.GetFiles();
                var filesToDelete = new List<FileInfo>();

                MainWindow.Logger.Log("_listOfFiles: " + _listOfFiles.Count);
                MainWindow.Logger.Log(
                    "_listOfFiles: ",
                    () =>
                    {
                        var output = string.Empty;

                        foreach (var file in _listOfFiles)
                        {
                            if (file == null)
                            {
                                output += "File is null" + Environment.NewLine;
                            }
                            else
                            {
                                output += file.FullName + Environment.NewLine;
                            }
                        }

                        return output;
                    });
                MainWindow.Logger.Log("filesInDestination: " + filesInDestination.Length);

                foreach (var fileToTest in filesInDestination)
                {
                    MainWindow.Logger.Log("Testing " + fileToTest.FullName);

                    foreach (var fileSource in _listOfFiles)
                    {
                        MainWindow.Logger.Log("against " + fileSource.FullName);

                        if (string.Compare(fileToTest.Name, fileSource.Name, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            MainWindow.Logger.Log("Match: " + fileToTest.FullName);
                            filesToDelete.Add(fileToTest);
                            break;
                        }
                    }
                }

                foreach (var file in filesToDelete)
                {
                    MainWindow.Logger.Log("Deleting file " + file.FullName);
                    File.Delete(file.FullName);
                }

                if (folder.GetFiles().Length == 0
                    && folder.GetDirectories().Length == 0)
                {
                    Directory.Delete(folder.FullName);
                }
            }
        }

        private void BuildListOfFiles()
        {
            _listOfFiles = new List<FileInfo>();

            BuildListOfFiles(ItemTemplatesSourcePathWpf);
            BuildListOfFiles(ItemTemplatesSourcePathSl);
            BuildListOfFiles(SnippetsSourcePath);
            BuildListOfFiles(SnippetsSourcePathWpf);
            BuildListOfFiles(SnippetsSourcePathSl);
        }

        private void BuildListOfFiles(string folderPath)
        {
            var sourcePath = Format(folderPath);
            var sourceFolder = new DirectoryInfo(Path.Combine(_resourcesFolder.FullName, sourcePath));

            MainWindow.Logger.Log("BuildListOfFiles " + folderPath);

            _listOfFiles.AddRange(sourceFolder.GetFiles());
        }

        private static void CleanupOldFolder(SettingsViewModel settings, string subPath)
        {
            MainWindow.Logger.Log("Cleaning up old folders");

            var oldFolderPath = Path.Combine(
                settings.TemplatesFolder.FullName,
                Format(subPath));

            if (Directory.Exists(oldFolderPath))
            {
                Directory.Delete(oldFolderPath, true);
                MainWindow.Logger.Log("Deleted " + oldFolderPath);
                return;
            }

            MainWindow.Logger.Log("Not found: " + oldFolderPath);
        }

        private void CopyToDestination(FileSystemInfo destination, string pathInResources)
        {
            var sourcePath = Format(pathInResources);
            var sourceFolder = new DirectoryInfo(Path.Combine(_resourcesFolder.FullName, sourcePath));

            var files = sourceFolder.GetFiles();
            foreach (var file in files)
            {
                MainWindow.Logger.Log("Copying file " + file.FullName + " to " + destination.FullName);
                file.CopyTo(Path.Combine(destination.FullName, file.Name), true);
            }
        }

        private void EditProjectFile(InstallType installType)
        {
            MainWindow.Logger.Log("Enter EditProjectFile");

            var projectFileModelName = installType == InstallType.SilverlightOnly
                                           ? Format(ProjectFileModelPathSl)
                                           : Format(ProjectFileModelPathWpf);

            var projectFileName = installType == InstallType.SilverlightOnly
                                      ? ProjectFileNameSl
                                      : ProjectFileNameWpf;

            var modelProjectFile = new FileInfo(Path.Combine(_resourcesFolder.FullName, projectFileModelName));

            if (!modelProjectFile.Exists)
            {
                throw new FileNotFoundException(string.Format(
                                                    CultureInfo.CurrentCulture,
                                                    Resources.NotFound,
                                                    modelProjectFile.FullName));
            }

            var projectTargetFile = new FileInfo(Path.Combine(_folderToZip.FullName, projectFileName));

            var dllFolderPath = installType == InstallType.SilverlightOnly
                                    ? Format(BinariesPathSl)
                                    : Format(BinariesPathWpf);

            var dllFolder = new DirectoryInfo(Path.Combine(_resourcesFolder.FullName, dllFolderPath));

            var line1 = string.Format(
                CultureInfo.CurrentCulture,
                ReplacementLine1,
                DllName,
                Settings.Default.DllVersion);

            var line3 = string.Format(
                CultureInfo.CurrentCulture,
                ReplacementLine3,
                Path.Combine(dllFolder.FullName, DllName));

            using (var reader = new StreamReader(modelProjectFile.FullName))
            {
                using (var writer = new StreamWriter(projectTargetFile.FullName, false))
                {
                    string line;
                    while ((line = reader.ReadLine()) != PlaceholderLine)
                    {
                        writer.WriteLine(line);
                    }

                    writer.WriteLine(line1);
                    writer.WriteLine(ReplacementLine2);
                    writer.WriteLine(line3);
                    writer.WriteLine(ReplacementLine4);

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            MainWindow.Logger.Log("Exit EditProjectFile");
        }

        private void Initialize()
        {
            _appDataFolder = SettingsFileHandler.AppDataFolder;

            var assemblyFile = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var assemblyFolder = new DirectoryInfo(assemblyFile.DirectoryName);
            _resourcesFolder = assemblyFolder.Parent;

            _blendTemplatesFolder = SettingsFileHandler.BlendDocumentsFolder;
        }

        private void MakeFolderToZip(InstallType installType, out FileInfo projectZipSourceFile)
        {
            var projectTemplateSourcePath = installType == InstallType.SilverlightOnly
                                                ? Format(ProjectTemplatesSourcePathSl)
                                                : Format(ProjectTemplatesSourcePathWpf);

            projectZipSourceFile = new FileInfo(Path.Combine(
                                                    Path.Combine(_resourcesFolder.FullName, projectTemplateSourcePath),
                                                    ProjectZipFileName));

            var subPath = installType == InstallType.WpfOnly
                              ? Format(ProjectTemplatesBlendTargetSubPathWpf)
                              : Format(ProjectTemplatesBlendTargetSubPathSl);

            subPath = Path.Combine(subPath, Path.GetFileNameWithoutExtension(projectZipSourceFile.Name));

            _folderToZip = new DirectoryInfo(Path.Combine(
                                                 _blendTemplatesFolder.FullName,
                                                 Format(subPath)));
        }

        private static FileInfo MakeProjectZipTargetFile(SettingsViewModel settings, InstallType installType)
        {
            var projectTemplatesFolder = installType == InstallType.SilverlightOnly
                                             ? settings.ProjectTemplatesFolderSl
                                             : settings.ProjectTemplatesFolderWpf;

            var projectZipTargetFile = new FileInfo(Path.Combine(
                                                        projectTemplatesFolder.FullName,
                                                        ProjectZipFileName));

            _listOfFiles.Add(projectZipTargetFile);

            return projectZipTargetFile;
        }

        private void UnzipItemTemplatesToBlend(InstallType installType)
        {
            var itemTemplateSourcePath = installType == InstallType.SilverlightOnly
                                             ? Format(ItemTemplatesSourcePathSl)
                                             : Format(ItemTemplatesSourcePathWpf);

            var subPath = installType == InstallType.SilverlightOnly
                              ? Format(ItemTemplatesBlendTargetSubPathSl)
                              : Format(ItemTemplatesBlendTargetSubPathWpf);

            var itemsDirectory = new DirectoryInfo(Path.Combine(_resourcesFolder.FullName, itemTemplateSourcePath));
            var itemTemplates = itemsDirectory.GetFiles("*.zip");

            foreach (var itemZipSourceFile in itemTemplates)
            {
                var targetFolderSubPath = Path.Combine(subPath, Path.GetFileNameWithoutExtension(itemZipSourceFile.Name));

                var targetFolder = new DirectoryInfo(Path.Combine(
                                                         _blendTemplatesFolder.FullName,
                                                         Format(targetFolderSubPath)));

                var zip = new FastZip();
                zip.ExtractZip(
                    itemZipSourceFile.FullName,
                    targetFolder.FullName,
                    FastZip.Overwrite.Always,
                    null,
                    null,
                    null,
                    false);
            }
        }

        private void UnzipProjectTemplateToBlend(InstallType installType)
        {
            FileInfo projectZipSourceFile;
            MakeFolderToZip(installType, out projectZipSourceFile);

            if (!projectZipSourceFile.Exists)
            {
                throw new FileNotFoundException(string.Format(
                                                    CultureInfo.CurrentCulture,
                                                    Resources.NotFound,
                                                    projectZipSourceFile.FullName));
            }

            var zip = new FastZip();
            zip.ExtractZip(
                projectZipSourceFile.FullName,
                _folderToZip.FullName,
                FastZip.Overwrite.Always,
                null,
                null,
                null,
                false);
        }

        private void ZipAndCopyProjectTemplateToStudio(InstallType installType)
        {
            MainWindow.Logger.Log("Enter ZipAndCopyProjectTemplateToStudio");

            var projectZipTargetFile = MakeProjectZipTargetFile(ViewModelLocator.SettingsStatic, installType);

            if (!_folderToZip.Exists)
            {
                MainWindow.Logger.Log(_folderToZip.FullName + " not found");
                throw new DirectoryNotFoundException(string.Format(
                                                         CultureInfo.CurrentCulture,
                                                         Resources.NotFound,
                                                         _folderToZip.FullName));
            }

            MainWindow.Logger.Log("projectZipTargetFile " + projectZipTargetFile.FullName);

            using (var stream = new FileStream(projectZipTargetFile.FullName, FileMode.Create))
            {
                MainWindow.Logger.Log("Creating zip file " + _folderToZip.FullName);

                var zip = new FastZip();
                zip.CreateZip(stream, _folderToZip.FullName, true, null, null);
            }

            MainWindow.Logger.Log("Exit ZipAndCopyProjectTemplateToStudio");
        }
    }
}