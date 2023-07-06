using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using MauiApp2.Models;


namespace MauiApp2.Views
{
    public partial class Haberler : ContentPage
    {
        private List<Kategori> kategoriler;
        private List<Item> haberler;

        public Haberler()
        {
            InitializeComponent();

            lstKategoriler.SelectionChanged += LstKategoriler_SelectionChanged;
            lstHaberler.SelectionChanged += LstHaberler_SelectionChanged;

            kategoriler = Kategori.liste;
            lstKategoriler.ItemsSource = kategoriler;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (lstKategoriler.SelectedItem == null)
            {
                // Varsayýlan olarak ilk kategoriyi seç
                lstKategoriler.SelectedItem = kategoriler.FirstOrDefault();
            }

            var selectedKategori = lstKategoriler.SelectedItem as Kategori;
            await HaberleriYukle(selectedKategori.Link);
        }

        private async void LstKategoriler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedKategori = e.CurrentSelection.FirstOrDefault() as Kategori;
            if (selectedKategori != null)
            {
                await HaberleriYukle(selectedKategori.Link);
            }
        }

        private async Task HaberleriYukle(string rssUrl)
        {
            try
            {
                var httpClient = new HttpClient();
                var rssIcerik = await httpClient.GetStringAsync(rssUrl);

                var xdoc = XDocument.Parse(rssIcerik);
                var haberlerElementleri = xdoc.Descendants("item");

                haberler = haberlerElementleri.Select(haberElementi => new Item
                {
                    title = (string)haberElementi.Element("title"),
                    pubDate = (string)haberElementi.Element("pubDate"),
                    link = (string)haberElementi.Element("link"),
                    guid = (string)haberElementi.Element("guid"),
                    author = (string)haberElementi.Element("author"),
                    thumbnail = (string)haberElementi.Element("thumbnail"),
                    description = (string)haberElementi.Element("description"),
                    content = (string)haberElementi.Element("content"),
                    enclosure = new Enclosure
                    {
                        link = (string)haberElementi.Element("enclosure")?.Attribute("url"),
                        type = (string)haberElementi.Element("enclosure")?.Attribute("type")
                    },
                    categories = haberElementi.Elements("category").Select(kategoriElementi => (object)kategoriElementi.Value).ToList()
                }).ToList();

                lstHaberler.ItemsSource = haberler;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", "Haberler yüklenirken bir hata oluþtu.", "Tamam");
            }
        }

        private void LstHaberler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seciliHaber = e.CurrentSelection.FirstOrDefault() as Item;
            if (seciliHaber != null)
            {
                // Seçilen haber öðesini iþleyin
            }
        }
    }
}
