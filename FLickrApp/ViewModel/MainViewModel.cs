using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace FLickrApp
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Photo> FlickrItems { get; set; }
        //public IEnumerable<PhotoUrl> Items { get; set; }

        IEnumerable<PhotoUrl> items;
        public IEnumerable<PhotoUrl> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public Command LoadItemsCommand { get; set; }

        public MainViewModel()
        {
            Title = "Flickr";
            FlickrItems = new ObservableCollection<Photo>();
            LoadItemsCommand = new Command(async () => await LoadItems());
            Items = localDb.AllPhotos;

            InitializeItems();
        }

        void InitializeItems()
        {
            var count = Items.Count();
            if(count == 0)
                LoadItems();
        }

        async Task LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items = Enumerable.Empty<PhotoUrl>();
                await localDb.DeleteAllAsync();
                FlickrItems.Clear();
                var flickrItems = await FlickrStore.GetItems();
                foreach (var item in flickrItems)
                {
                    FlickrItems.Add(item);
                    await localDb.AddNewItemAsync(item);
                }

                Items = localDb.AllPhotos;

                Debug.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
