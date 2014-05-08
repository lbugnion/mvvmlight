using GalaSoft.MvvmLight.Test__WPSL81_.Resources;

namespace GalaSoft.MvvmLight.Test__WPSL81_
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}