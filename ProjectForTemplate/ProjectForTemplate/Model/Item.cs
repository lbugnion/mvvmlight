namespace ProjectForTemplate.Model
{
    /// <summary>
    /// This is a business object.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        /// <param name="text">A text parameter.</param>
        public Item(string text)
        {
            TextInItem = text;
        }

        /// <summary>
        /// Gets a string.
        /// </summary>
        public string TextInItem
        {
            get;
            private set;
        }
    }
}