using Xamarin.Forms;

namespace FLickrApp
{
    public partial class App : Application
    {
        public static readonly string BackendUrl = "https://api.flickr.com/services/rest";
        public static readonly string AppKey = "93bc08e41b32fdc14779d3ac54cd4af8";
        public static readonly string SecretKey = "ce014208e991d34d";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
