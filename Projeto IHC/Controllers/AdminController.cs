using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Projeto_IHC.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class AdminController : Controller
    {
        public readonly IHttpClientFactory HttpClientFactory;
        public readonly Contexto db;
        public AdminController(IHttpClientFactory _httpClientFactory, Contexto _db)
        {
            HttpClientFactory = _httpClientFactory;
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaFilmes()
        {
            return View(db.FILMES.ToList());
        }

        public IActionResult ListaSessoes()
        {
            return View(db.SESSOES.ToList());
        }

        public IActionResult AdicionarFilme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarFilme(Entidades.Filme DadosTela)
        {
            db.FILMES.Add(DadosTela);
            db.SaveChanges();
            return RedirectToAction("ListaFilmes");
        }

        public IActionResult EditarFilme()
        {
            return View(db.FILMES.ToList());
        }

        [HttpPost]
        public IActionResult EditarFilme(int id, Entidades.Filme DadosTela)
        {
            db.FILMES.Update(DadosTela);
            db.SaveChanges();
            return RedirectToAction("ListaFilmes");
        }

        public IActionResult RemoverFilme(int id)
        {
            db.FILMES.Remove(
                db.FILMES.Where(a => a.Id == id).FirstOrDefault()
                );
            return RedirectToAction("ListaFilmes");
        }

        public IActionResult AdicionarSessao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarSessao(Entidades.Sessao DadosTela)
        {
            db.SESSOES.Add(DadosTela);
            db.SaveChanges();
            return RedirectToAction("ListaSessao");
        }

        public IActionResult EditarSessao(int id)
        {
            return View(db.SESSOES.Where(a=> a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult EditarSessao(int id, Entidades.Sessao DadosTela)
        {
            db.SESSOES.Update(DadosTela);
            db.SaveChanges();
            return RedirectToAction("ListaSessoes");
        }

        public IActionResult RemoverSessao(int id)
        {
            db.SESSOES.Remove(
                db.SESSOES.Where(a => a.Id == id).FirstOrDefault()
                );
            return RedirectToAction("ListaSessoes");
        }

        public async Task<string> GetJSON()
        {
            var URL = "https://api.themoviedb.org/3/movie/550?api_key=2e06b12031eb2557fa256ed1f6fd5651&language=pt-BR";
            var httpclient = HttpClientFactory.CreateClient();

            var response = await httpclient.GetAsync(URL);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

    }
}
