using Android.App;
using Android.OS;
using Flowers.Data.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;

namespace Flowers
{
    [Activity(Label = "Add Comment")]
    public partial class AddCommentActivity
    {
        private Binding<string, string> _saveBinding;

        private FlowerViewModel Vm
        {
            get;
            set;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddComment);

            // Retrieve navigation parameter and set as current "DataContext"
            Vm = GlobalNavigation.GetAndRemoveParameter<FlowerViewModel>(Intent);

            // Avoid aggressive linker problem which removes the TextChanged event
            CommentText.TextChanged += (s, e) =>
            {
            };

            _saveBinding = this.SetBinding(
                () => CommentText.Text);

            // Avoid aggressive linker problem which removes the Click event
            SaveCommentButton.Click += (s, e) =>
            {
            };

            SaveCommentButton.SetCommand(
                "Click",
                Vm.SaveCommentCommand,
                _saveBinding);
        }
    }
}