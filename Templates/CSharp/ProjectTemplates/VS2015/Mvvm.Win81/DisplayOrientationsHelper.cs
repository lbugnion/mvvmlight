using Windows.Graphics.Display;

namespace $safeprojectname$.Common
{
    public static class DisplayOrientationsHelper
    {
        public static PageOrientations GetPageOrientation(this DisplayOrientations orientation)
        {
            switch (orientation)
            {
                case DisplayOrientations.LandscapeFlipped:
                    return PageOrientations.LandscapeFlipped;

                case DisplayOrientations.Portrait:
                    return PageOrientations.Portrait;

                case DisplayOrientations.PortraitFlipped:
                    return PageOrientations.PortraitFlipped;

                default:
                    return PageOrientations.Landscape;
            }
        }
    }
}