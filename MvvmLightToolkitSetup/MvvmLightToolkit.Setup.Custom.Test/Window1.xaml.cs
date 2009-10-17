using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MvvmLightToolkit.Setup.Custom.ViewModel;
using System.IO;
using System.Reflection;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLightToolkit.Setup.Custom.Test
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            MessageBox.Show("Please execute CleanMvvmLightToolkitSetupCustomTest.bat before pressing OK");

            MessageBox.Show("Please execute CleanAll.bat before pressing OK");

            Prepare();

            Messenger.Default.Register<DialogMessage>(this, HandleDialogMessage);

            InitializeComponent();
        }

        private static void HandleDialogMessage(DialogMessage message)
        {
            var result = MessageBox.Show(message.Content,
                                         message.Caption,
                                         message.Button,
                                         message.Icon,
                                         message.DefaultResult,
                                         message.Options);

            message.ProcessCallback(result);
        }

        private void Prepare()
        {
            var assembly = new FileInfo(Assembly.GetExecutingAssembly().Location);

            var rootFolder = assembly.Directory.Parent.Parent.Parent;

            var targetFolder = assembly.Directory.Parent;

            var resourcesFolder = new DirectoryInfo(System.IO.Path.Combine(rootFolder.FullName,
                                                                           "Resources"));

            PrepareFolder(resourcesFolder, targetFolder);
        }

        private static void PrepareFolder(DirectoryInfo sourceFolder, DirectoryInfo targetFolder)
        {
            if (!Directory.Exists(targetFolder.FullName))
            {
                Directory.CreateDirectory(targetFolder.FullName);
            }

            foreach (var file in sourceFolder.GetFiles())
            {
                if (!file.Name.EndsWith("scc"))
                {
                    file.CopyTo(System.IO.Path.Combine(targetFolder.FullName, file.Name), true);
                }
            }

            foreach (var directory in sourceFolder.GetDirectories())
            {
                var targetFolderChild = new DirectoryInfo(System.IO.Path.Combine(targetFolder.FullName, directory.Name));

                PrepareFolder(directory, targetFolderChild);
            }
        }
    }
}
