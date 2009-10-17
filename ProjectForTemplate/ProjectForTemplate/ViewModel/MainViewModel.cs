using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectForTemplate.Model;
using ProjectForTemplate.Properties;

namespace ProjectForTemplate.ViewModel
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
        /// The <see cref="DialogResult" /> property's name.
        /// </summary>
        public const string DialogResultPropertyName = "DialogResult";

        /// <summary>
        /// The <see cref="Items" /> property's name.
        /// </summary>
        public const string ItemsName = "Items";

        /// <summary>
        /// The <see cref="Text" /> property's name.
        /// </summary>
        public const string TextName = "Text";

        /// <summary>
        /// The <see cref="IsDirty" /> property's name.
        /// </summary>
        public const string IsDirtyName = "IsDirty";

        private MessageBoxResult _dialogResult = MessageBoxResult.None;

        private string _textProperty = Resources.TextMainViewModel;

        private bool _isDirty;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                for (var index = 0; index < 20; index++)
                {
                    var item = new Item(string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.TextItemDesign,
                        index));

                    var itemVM = new ItemViewModel(item)
                    {
                        TextInItemVM = string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.TextItemViewModelDesign,
                            index)
                    };

                    Items.Add(itemVM);
                }
            }
            else
            {
                // This code simulates the creation of runtime items.
                // In reality, you would rather connect to a DB,
                // or to a web service, etc...
                for (var index = 0; index < 20; index++)
                {
                    var item = new Item(string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.TextItemRuntime,
                        index));

                    var itemVM = new ItemViewModel(item)
                    {
                        TextInItemVM = string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.TextItemViewModelRuntime,
                            index)
                    };

                    Items.Add(itemVM);
                }

                ButtonCommand = new RelayCommand(() =>
                {
                    var dialogMessage = new DialogMessage(
                        this,
                        typeof(MainWindow),
                        Resources.MessageBoxText,
                        r => DialogResult = r)
                    {
                        Button = MessageBoxButton.YesNo,
                        Caption = Resources.MessageBoxCaption,
                        DefaultResult = MessageBoxResult.No,
                        Icon = MessageBoxImage.Question
                    };

                    Messenger.Default.Send(dialogMessage);
                });
            }

            // Register to get all the PropertyChangedMessages broadcasted.
            Messenger.Default.Register<PropertyChangedMessageBase>(this, HandlePropertyMessage);
        }

        private void HandlePropertyMessage(PropertyChangedMessageBase message)
        {
            var propertyMessage = message as PropertyChangedMessage<string>;
            if (propertyMessage != null
                && propertyMessage.Sender.GetType() == typeof(ItemViewModel)
                    && propertyMessage.PropertyName == ItemViewModel.TextInItemVMPropertyName)
            {
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets the command executed when the main button gets clicked.
        /// </summary>
        public RelayCommand ButtonCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the (localized) content displayed by the main button.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public string ButtonContent
        {
            get
            {
                return Resources.ButtonContent;
            }
        }

        /// <summary>
        /// Gets the DialogResult property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MessageBoxResult DialogResult
        {
            get
            {
                return _dialogResult;
            }

            private set
            {
                if (_dialogResult == value)
                {
                    return;
                }

                ////var oldValue = _dialogResult;
                _dialogResult = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(DialogResultPropertyName);

                // Update bindings and broadcast change using GalaSoft.Utility.Messenging
                ////RaisePropertyChanged(DialogResultPropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="Item" /> instances.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the Text property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public string Text
        {
            get
            {
                return _textProperty;
            }

            set
            {
                if (_textProperty == value)
                {
                    return;
                }

                var oldValue = _textProperty;
                _textProperty = value;

                // Update bindings and broadcast change using GalaSoft.Utility.Messenging
                RaisePropertyChanged(TextName, oldValue, value, true);
            }
        }

        /// <summary>
        /// Gets a value indicating whether there are unsaved changes in the ViewModel.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }

            private set
            {
                if (_isDirty == value)
                {
                    return;
                }

                _isDirty = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(IsDirtyName);
            }
        }

        /// <summary>
        /// Gets the (localized) title of the main window.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public string WindowTitle
        {
            get
            {
                return Resources.WindowTitle;
            }
        }
    }
}