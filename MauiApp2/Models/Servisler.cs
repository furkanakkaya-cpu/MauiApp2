using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Models
{
    public class Servisler
    {
        public static async Task<string> HaberleriGetir(Kategori ctg)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = $"http://api.rss2json.com/v1/api.json?rss_url={ctg.Link}";
                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string jsondata = await response.Content.ReadAsStringAsync();
                return jsondata;
            }
            catch
            {
                return null;
            }
        }
    }
}
