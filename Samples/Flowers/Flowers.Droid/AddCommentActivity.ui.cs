using Android.Widget;
using Flowers.Helpers;

namespace Flowers
{
    public partial class AddCommentActivity : ActivityBaseEx
    {
        private EditText _commentText;
        private Button _saveCommentButton;

        public EditText CommentText
        {
            get
            {
                return _commentText
                       ?? (_commentText = FindViewById<EditText>(Resource.Id.CommentText));
            }
        }

        public Button SaveCommentButton
        {
            get
            {
                return _saveCommentButton
                       ?? (_saveCommentButton = FindViewById<Button>(Resource.Id.SaveCommentButton));
            }
        }
    }
}