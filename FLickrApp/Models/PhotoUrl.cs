using System;
using Realms;

namespace FLickrApp
{
    public class PhotoUrl : RealmObject
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}