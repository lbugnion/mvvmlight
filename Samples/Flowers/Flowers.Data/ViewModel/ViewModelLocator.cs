using System.Diagnostics.CodeAnalysis;
using Flowers.Data.Design;
using Flowers.Data.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Flowers.Data.ViewModel
{
    public class ViewModelLocator
    {
        public const string AddCommentPageKey = "AddCommentPage";
        public const string DetailsPageKey = "DetailsPage";

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                if (!SimpleIoc.Default.IsRegistered<GalaSoft.MvvmLight.Views.INavigationService>())
                {
                    SimpleIoc.Default.Register<GalaSoft.MvvmLight.Views.INavigationService, DesignNavigationService>();
                }

                SimpleIoc.Default.Register<IFlowersService, DesignFlowersService>();
            }
            else
            {
                SimpleIoc.Default.Register<IFlowersService, FlowersService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }
    }
}