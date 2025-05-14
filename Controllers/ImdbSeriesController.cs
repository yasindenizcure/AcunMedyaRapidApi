using AcunMedyaRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AcunMedyaRapidApi.Controllers
{
    public class ImdbSeriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient(); //consume işlemi client oluşturuyoruz
            var request = new HttpRequestMessage    
            {
                Method = HttpMethod.Get, //istek yapılan method türü
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"), //istek yapılacak url
                Headers =
    {
        { "x-rapidapi-key", "128bd94e78msh8a7d11cb52bce26p11b9f4jsn6129c3707d09" }, //herkesin apisi kendine özel
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode(); //istek başarılı olup olmadığını bize geri dönen durum kodu
                var body = await response.Content.ReadAsStringAsync(); //içeriği okumasını sağlıyor
                var value = JsonConvert.DeserializeObject<List<ImdbSeriesViewModel>>(body);// json formatındaki veriyi deserialize ediyoruz
                return View(value);
                //Console.WriteLine(body);
            }

        }
    }
}
