using Xamarin.Forms;

namespace FLickrApp
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //ItemsListView.SelectedItem = null;
            var item = e.SelectedItem as PhotoUrl;
            if (item == null)
                return;

            await Navigation.PushAsync(new LargeImagePage(item), false);
        }
    }
}
