using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace FLickrApp
{
    public class FlickrData : IFlickrData<Photo>
    {
        HttpClient client;
        IEnumerable<Photo> items;

        public FlickrData()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<Photo>();
        }

        public async Task<IEnumerable<Photo>> GetItems()
        {
            var method = $"?method=flickr.photos.search&api_key={App.AppKey}&text=space&format=json&nojsoncallback=1";
            var json = await client.GetStringAsync(method);
            var result = await Task.Run(() => JsonConvert.DeserializeObject<FlickrItem>(json));

            if (result.stat == "ok")
            {
                return result.photos.photo;
            }
            else
            {
                return items;
            }
        }
    }
}
