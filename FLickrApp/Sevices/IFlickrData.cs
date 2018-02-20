using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLickrApp
{
    public interface IFlickrData<T>
    {
        Task<IEnumerable<T>> GetItems();
    }
}