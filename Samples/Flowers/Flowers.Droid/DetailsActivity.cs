using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Flowers.Data.Model;
using Flowers.Data.ViewModel;
using Flowers.Helpers;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;

namespace Flowers
{
    [Activity(Label = "Flower Details")]
    public partial class DetailsActivity
    {
        private FlowerViewModel Vm
        {
            get;
            set;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Details);

            // Retrieve navigation parameter and set as current "DataContext"
            Vm = GlobalNavigation.GetAndRemoveParameter<FlowerViewModel>(Intent);

            var headerView = LayoutInflater.Inflate(Resource.Layout.CommentsListHeaderView, null);
            headerView.FindViewById<TextView>(Resource.Id.NameText).Text = Vm.Model.Name;
            headerView.FindViewById<TextView>(Resource.Id.DescriptionText).Text = Vm.Model.Description;

            CommentsList.AddHeaderView(headerView);
            CommentsList.Adapter = Vm.Model.Comments.GetAdapter(GetCommentTemplate);

            ImageDownloader.AssignImageAsync(FlowerImageView, Vm.Model.Image, this);

            // Avoid aggressive linker problem which removes the Click event
            AddCommentButton.Click += (s, e) =>
            {
            };

            AddCommentButton.SetCommand(
                "Click",
                Vm.AddCommentCommand);
        }

        private View GetCommentTemplate(int position, Comment comment, View convertView)
        {
            convertView = LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = comment.Text;
            convertView.FindViewById<TextView>(Android.Resource.Id.Text2).Text = comment.InputDate.ToString();
            return convertView;
        }
    }
}