using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;

namespace FLickrApp
{
    public class DataStore : IDataStore<Photo, PhotoUrl>
    {
        private Realm realm;
        public IEnumerable<PhotoUrl> AllPhotos { get; set; }

        public DataStore()
        {
            realm = Realm.GetInstance();
            AllPhotos = realm.All<PhotoUrl>();
        }

        public async Task<bool> AddNewItemAsync(Photo item)
        {
            //var transaction = realm.BeginWrite();
            var photoUrl = $"http://farm{item.farm}.staticflickr.com/{item.server}/{item.id}_{item.secret}_h.jpg";
            var newItem = new PhotoUrl
            {
                Title = item.title,
                Url = photoUrl
            };
            realm.Write(() => realm.Add(newItem));
            AllPhotos = realm.All<PhotoUrl>();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAllAsync()
        {
            realm.Write(() => realm.RemoveAll());
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<PhotoUrl>> GetItemsAsync()
        {
            var items = realm.All<PhotoUrl>();
            return await Task.FromResult(items);
        }
    }
}
