using AcunMedyaRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AcunMedyaRapidApi.Controllers
{
    public class ChuckNorrisController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random"),
                Headers =
    {
        { "x-rapidapi-key", "128bd94e78msh8a7d11cb52bce26p11b9f4jsn6129c3707d09" },
        { "x-rapidapi-host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com" },
        { "accept", "application/json" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ChuckNorrisViewModel>(body);
                return View(value);
            }
        }
    }
}
