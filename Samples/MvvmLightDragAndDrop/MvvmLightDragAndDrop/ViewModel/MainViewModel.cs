using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.IO;

namespace MvvmLightDragAndDrop.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="DroppedFileContent" /> property's name.
        /// </summary>
        public const string DroppedFileContentPropertyName = "DroppedFileContent";

        private string _droppedFile = "Drop file here";

        /// <summary>
        /// Gets the DroppedFileContent property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DroppedFileContent
        {
            get
            {
                return _droppedFile;
            }

            set
            {
                if (_droppedFile == value)
                {
                    return;
                }

                _droppedFile = value;
                RaisePropertyChanged(DroppedFileContentPropertyName);
            }
        }

        public RelayCommand<DragEventArgs> HandleDropCommand
        {
            get;
            private set;
        }

        public MainViewModel()
        {
            HandleDropCommand = new RelayCommand<DragEventArgs>(e =>
            {
                if (e.Data == null)
                {
                    return;
                }

                var files = e.Data.GetData(DataFormats.FileDrop)
                    as FileInfo[];

                // This works with multiple files, but in that
                // simple case, let's just handle the 1st one
                if (files == null
                    || files.Length == 0)
                {
                    DroppedFileContent = "No files";
                    return;
                }

                var file = files[0];

                if (!file.Extension.ToLower().Equals(".txt"))
                {
                    DroppedFileContent = "Not a TXT file";
                    return;
                }

                using (var stream = file.OpenRead())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        // Read the first line
                        var line = reader.ReadLine();
                        DroppedFileContent = line;
                    }
                }                
            });
        }
    }
}