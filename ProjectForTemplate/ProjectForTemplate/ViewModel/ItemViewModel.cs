using GalaSoft.MvvmLight;
using ProjectForTemplate.Model;
using System.Diagnostics.CodeAnalysis;

namespace ProjectForTemplate.ViewModel
{
    /// <summary>
    /// A ViewModel for the Item class.
    /// </summary>
    public class ItemViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="TextInItemVM" /> property's name.
        /// </summary>
        public const string TextInItemVMPropertyName = "TextInItemVM";

        /// <summary>
        /// The <see cref="Model" /> property's name.
        /// </summary>
        public const string ModelPropertyName = "Model";

        private string _text;

        private Item _model;

        /// <summary>
        /// Initializes a new instance of the ItemViewModel class.
        /// </summary>
        /// <param name="item">The instance of the <see cref="Item" /> class that
        /// this ViewModel wraps.</param>
        [SuppressMessage(
            "Microsoft.Usage", 
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemViewModel(Item item)
        {
            Model = item;
        }

        /// <summary>
        /// Gets or sets the Text property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TextInItemVM
        {
            get
            {
                return _text;
            }

            set
            {
                if (_text == value)
                {
                    return;
                }

                _text = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(TextInItemVMPropertyName);
            }
        }

        /// <summary>
        /// Gets the instance of the <see cref="Item" /> class that
        /// this ViewModel wraps.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Item Model
        {
            get
            {
                return _model;
            }

            private set
            {
                if (_model == value)
                {
                    return;
                }

                _model = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ModelPropertyName);
            }
        }
    }
}