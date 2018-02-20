using System;

namespace FLickrApp
{
    public class LargeImageViewModel : BaseViewModel
    {
        string url = string.Empty;
        public string Url
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }

        public LargeImageViewModel()
        {
        }
    }
}