using Android.Widget;
using Flowers.Helpers;

namespace Flowers
{
    public partial class DetailsActivity : ActivityBaseEx
    {
        private Button _addCommentButton;
        private ListView _commentsList;
        private ImageView _flowerImageView;

        public Button AddCommentButton
        {
            get
            {
                return _addCommentButton
                       ?? (_addCommentButton = FindViewById<Button>(Resource.Id.AddCommentButton));
            }
        }

        public ListView CommentsList
        {
            get
            {
                return _commentsList
                       ?? (_commentsList = FindViewById<ListView>(Resource.Id.CommentsList));
            }
        }

        public ImageView FlowerImageView
        {
            get
            {
                return _flowerImageView
                       ?? (_flowerImageView = FindViewById<ImageView>(Resource.Id.FlowerImageView));
            }
        }
    }
}