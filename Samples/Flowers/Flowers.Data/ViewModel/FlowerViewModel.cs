using System;
using Flowers.Data.Design;
using Flowers.Data.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Flowers.Data.ViewModel
{
    public class FlowerViewModel : ViewModelBase
    {
        private readonly IFlowersService _flowerService;

        private RelayCommand _addCommentCommand;
        private RelayCommand<string> _saveCommentCommand;

        public RelayCommand AddCommentCommand
        {
            get
            {
                return _addCommentCommand
                       ?? (_addCommentCommand = new RelayCommand(
                           () =>
                           {
                               var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                               nav.NavigateTo(ViewModelLocator.AddCommentPageKey, this);
                           }));
            }
        }

        public string ImageFileName
        {
            get
            {
                return ImageUri.LocalPath;
            }
        }

        public Uri ImageUri
        {
            get
            {
                return new Uri(Model.Image);
            }
        }

        public Flower Model
        {
            get;
            private set;
        }

        /// <summary>
        /// The <see cref="IsSaving" /> property's name.
        /// </summary>
        public const string IsSavingPropertyName = "IsSaving";

        private bool _isSaving = false;

        /// <summary>
        /// Sets and gets the IsSaving property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsSaving
        {
            get
            {
                return _isSaving;
            }
            set
            {
                if (Set(() => IsSaving, ref _isSaving, value))
                {
                    SaveCommentCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public RelayCommand<string> SaveCommentCommand
        {
            get
            {
                return _saveCommentCommand
                       ?? (_saveCommentCommand = new RelayCommand<string>(
                           async text =>
                           {
                               IsSaving = true;
                               Model.Comments.Add(
                                   new Comment
                                   {
                                       Id = Guid.NewGuid().ToString(),
                                       InputDate = DateTime.Now,
                                       Text = text
                                   });

                               var result = await _flowerService.Save(Model);

                               if (!result)
                               {
                                   // Handle error when saving
                                   var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                                   await
                                       dialog.ShowError(
                                           "Error when saving, your comment was not saved",
                                           "Error",
                                           "OK",
                                           null);
                               }

                               var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                               nav.GoBack();
                               IsSaving = false;
                           },
                           text => !string.IsNullOrEmpty(text) && !IsSaving));
            }
        }

        public FlowerViewModel(IFlowersService flowerService, Flower model)
        {
            _flowerService = flowerService;
            Model = model;
        }

#if DEBUG
        // This constructor is used in the Windows Phone app at design time,
        // for the Blend visual designer.
        public FlowerViewModel()
        {
            if (IsInDesignMode)
            {
                var service = new DesignFlowersService();
                Model = service.GetFlower(0);
            }
        }
#endif
    }
}