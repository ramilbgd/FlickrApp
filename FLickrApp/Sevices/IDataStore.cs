using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLickrApp
{
    public interface IDataStore<T, P>
    {
        IEnumerable<P> AllPhotos { get; set; }
        Task<bool> AddNewItemAsync(T item);
        Task<IEnumerable<P>> GetItemsAsync();
        Task<bool> DeleteAllAsync();
    }
}