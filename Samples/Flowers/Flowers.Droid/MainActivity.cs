using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Flowers.Data.ViewModel;
using Flowers.Helpers;
using GalaSoft.MvvmLight.Helpers;

namespace Flowers
{
    [Activity(Label = "Flowers", MainLauncher = true, Icon = "@drawable/icon")]
    public partial class MainActivity : AdapterView.IOnItemClickListener
    {
        private Binding _lastLoadedBinding;

        public MainViewModel Vm
        {
            get
            {
                return App.Locator.Main;
            }
        }

        // Implementing AdapterView.IOnItemClickListener
        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            Vm.ShowDetailsCommand.Execute(Vm.Flowers[position]);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Avoid aggressive linker problem which removes the Click event
            RefreshButton.Click += (s, e) =>
            {
            };

            RefreshButton.SetCommand(
                "Click",
                Vm.RefreshCommand);

            _lastLoadedBinding = this.SetBinding(
                () => Vm.LastLoadedFormatted,
                () => LastLoadedText.Text);

            FlowersList.Adapter = Vm.Flowers.GetAdapter(GetFlowerAdapter);
            FlowersList.OnItemClickListener = this;
        }

        private View GetFlowerAdapter(int position, FlowerViewModel flower, View convertView)
        {
            // Not reusing views here
            convertView = LayoutInflater.Inflate(Resource.Layout.FlowerTemplate, null);

            var title = convertView.FindViewById<TextView>(Resource.Id.NameTextView);
            title.Text = flower.Model.Name;

            var desc = convertView.FindViewById<TextView>(Resource.Id.DescriptionTextView);
            desc.Text = flower.Model.Description;

            var image = convertView.FindViewById<ImageView>(Resource.Id.FlowerImageView);
            ImageDownloader.AssignImageAsync(image, flower.Model.Image, this);

            return convertView;
        }
    }
}