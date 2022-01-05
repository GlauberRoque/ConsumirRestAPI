using ConsumirApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumirApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Pessoas()
        {
            string BaseUrl = "http://localhost:5043/";

            List<Pessoa>? pessoas = new List<Pessoa>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/pessoas");
            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(dados);
            }
            return View(pessoas);

        }

       public async Task<ActionResult> PessoaId(int id)
        {
            string BaseUrl = "http://localhost:5043/";
            Pessoa? p = new Pessoa();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/pessoas/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Pessoa>(dados);
            }
            return View(p);

        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(Pessoa p)
        {
            string BaseUrl = "http://localhost:5043/";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsJsonAsync(BaseUrl + "api/pessoas", p);

            return RedirectToAction("pessoas");
        }

        public IActionResult Alterar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Alterar(Pessoa p, int id)
        {
            string BaseUrl = "http://localhost:5043/";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/pessoas/" + id, p);

            return RedirectToAction("pessoas");

        }

        public IActionResult Deletar()
        {
            return View();
        }

        public async Task<ActionResult> Deletar(int id)
        {
            string BaseUrl = "http://localhost:5043/";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/pessoas/" + id);

            return RedirectToAction("pessoas");

        }

    }
}
