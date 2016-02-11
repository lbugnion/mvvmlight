using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ObservableTableAndCollectionViewSource.ViewModel
{
    /// <summary>
    /// This class contains static references to the most relevant view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        public const string SecondPageKey = "UITableViewTableSourceController";
        public const string ThirdPageKey = "CollectionViewController";

        /// <summary>
        /// Gets the Main property.
        /// </summary>
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

        /// <summary>
        /// This property can be used to force the application to run with design time data.
        /// </summary>
        public static bool UseDesignTimeData
        {
            get
            {
                return false;
            }
        }

        static ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}