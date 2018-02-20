using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FLickrApp
{
    public partial class LargeImagePage : ContentPage
    {
        LargeImageViewModel viewModel;

        public LargeImagePage(PhotoUrl photo)
        {
            InitializeComponent();

            BindingContext = viewModel = new LargeImageViewModel();
            viewModel.Title = photo.Title;
            viewModel.Url = photo.Url;
        }
    }
}
