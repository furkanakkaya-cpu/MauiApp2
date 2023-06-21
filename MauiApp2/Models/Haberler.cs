using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Models
{
    public class Enclosure
    {
        public string link { get; set; }
        public string type { get; set; }
    }
    public class Feed
    {
        public string url { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    }
    public class Item
    {
        public string title { get; set; }
        public string pubDate { get; set; }
        public string link { get; set; }
        public string guid { get; set; }
        public string auther { get; set; }
        public string thumbnail { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public Enclosure enclosure { get; set; }
        public List<object> categories { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public Feed feed { get; set; }
        public List<Item> items { get; set; }

    }
    public class Kategori
    {
        public string Baslik { get; set; }
        public string Link { get; set; }

        public static List<Kategori> liste = new Liste<Kategori>()
        {
            new Kategori() { Baslik = "Manşet", Link = "https://www.trthaber.com/manset_articles.rss" },
            new Kategori() { Baslik = "Son Dakika", Link = "https://www.trthaber.com/manset_articles.rss" },
            new Kategori() { Baslik = "Gündem", Link = "https://www.trthaber.com/manset_articles.rss" },
            new Kategori() { Baslik = "Ekonomi", Link = "https://www.trthaber.com/manset_articles.rss" },
            new Kategori() { Baslik = "Güncel", Link = "https://www.trthaber.com/manset_articles.rss" },
        };
    }
}

