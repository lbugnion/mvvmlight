namespace ProjectForTemplates.Common
{
    public enum PageOrientations
    {
        // Summary:
        //     No display orientation is specified.
        None = 0,
        //
        // Summary:
        //     Specifies that the monitor is oriented in landscape mode where the width
        //     of the display viewing area is greater than the height.
        Landscape = 1,
        //
        // Summary:
        //     Specifies that the monitor rotated 90 degrees in the clockwise direction
        //     to orient the display in portrait mode where the height of the display viewing
        //     area is greater than the width.
        Portrait = 2,
        //
        // Summary:
        //     Specifies that the monitor rotated another 90 degrees in the clockwise direction
        //     (to equal 180 degrees) to orient the display in landscape mode where the
        //     width of the display viewing area is greater than the height. This landscape
        //     mode is flipped 180 degrees from the Landscape mode.
        LandscapeFlipped = 4,
        //
        // Summary:
        //     Specifies that the monitor rotated another 90 degrees in the clockwise direction
        //     (to equal 270 degrees) to orient the display in portrait mode where the height
        //     of the display viewing area is greater than the width. This portrait mode
        //     is flipped 180 degrees from the Portrait mode.
        PortraitFlipped = 8,
        //
        // Summary:
        //     Specifies that the page is in "snap mode" or "split mode".
        Snap = 16,
    }
}