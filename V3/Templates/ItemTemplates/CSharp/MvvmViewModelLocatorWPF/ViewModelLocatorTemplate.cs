/*
  In App.xaml:
  <Application.Resources>
      <vm:$safeitemname$ xmlns:vm="clr-namespace:$rootnamespace$"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
  
  OR (WPF only):
  
  xmlns:vm="clr-namespace:$rootnamespace$"
  DataContext="{Binding Source={x:Static vm:$safeitemname$.ViewModelNameStatic}}"
*/

namespace $rootnamespace$
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// Use the <strong>mvvmlocatorproperty</strong> snippet to add ViewModels
    /// to this locator.
    /// </para>
    /// <para>
    /// In Silverlight and WPF, place the $safeitemname$ in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:$safeitemname$ xmlns:vm="clr-namespace:$rootnamespace$"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// You can also use Blend to do all this with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// <para>
    /// In <strong>*WPF only*</strong> (and if databinding in Blend is not relevant), you can delete
    /// the ViewModelName property and bind to the ViewModelNameStatic property instead:
    /// </para>
    /// <code>
    /// xmlns:vm="clr-namespace:$rootnamespace$"
    /// DataContext="{Binding Source={x:Static vm:$safeitemname$.ViewModelNameStatic}}"
    /// </code>
    /// </summary>
    public class $safeitemname$
    {
        /// <summary>
        /// Initializes a new instance of the $safeitemname$ class.
        /// </summary>
        public $safeitemname$()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view models
            ////}
            ////else
            ////{
            ////    // Create run time view models
            ////}
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            // Call ClearViewModelName() for each ViewModel.
        }
    }
}