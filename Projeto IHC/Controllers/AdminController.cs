using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_IHC.Models;
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
        public readonly Contexto db;
        public AdminController(Contexto _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                ViewData["admin"] = User.Identity.Name;

            return View();
        }

        public IActionResult ListaFilmes()
        {
            if (User.Identity.IsAuthenticated)
                ViewData["admin"] = User.Identity.Name;

            return View(db.FILMES.ToList());
        }

        public IActionResult ListaSessoes()
        {
            if (User.Identity.IsAuthenticated)
                ViewData["admin"] = User.Identity.Name;

            var sessoes = new List<Entidades.Sessao>(db.SESSOES.ToList());

            foreach (var sessao in sessoes)
            {
                sessao.Filme = db.FILMES.FirstOrDefault(f => f.Id == sessao.FilmeId);
            }
            return View(sessoes);
        }

        public IActionResult AdicionarFilme()
        {
            if (User.Identity.IsAuthenticated)
                ViewData["admin"] = User.Identity.Name;

            return View();
        }

        [HttpPost]
        public IActionResult AdicionarFilme(Entidades.Filme DadosTela)
        {
            if (db.FILMES.Any(f => f.Nome == DadosTela.Nome))
            {
                TempData["error"] = "Filme já cadastrado, insira outro nome.";
                return RedirectToAction("AdicionarFilme");
            }

            db.FILMES.Add(DadosTela);
            db.SaveChanges();
            return RedirectToAction("ListaFilmes");
        }

        public IActionResult EditarFilme(int id)
        {
            if (User.Identity.IsAuthenticated)
                ViewData["admin"] = User.Identity.Name;

            return View(db.FILMES.Where(f => f.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult EditarFilme(Entidades.Filme DadosTela)
        {
            db.FILMES.Update(DadosTela);
            db.SaveChanges();
            return RedirectToAction("ListaFilmes");
        }

        public IActionResult RemoverFilme(int id)
        {
            if (User.Identity.IsAuthenticated)
                ViewData["admin"] = User.Identity.Name;

            if (db.SESSOES.Where(s => s.FilmeId == id).Any() == true)
            {
                TempData["error"] = "Não é possível remover o filme, pois existem sessões associadas a ele.";
                return RedirectToAction("ListaFilmes");
            }
            else
            {
                db.FILMES.Remove(db.FILMES.Where(f => f.Id == id).FirstOrDefault());
                db.SaveChanges();
                return RedirectToAction("ListaFilmes");
            }
        }

        public IActionResult AdicionarSessao()
        {
            if (User.Identity.IsAuthenticated)
                ViewData["admin"] = User.Identity.Name;
            AdicionarSessaoModel model = new()
            {
                FilmesDisponiveis = db.FILMES.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AdicionarSessao(AdicionarSessaoModel DadosTela)
        {
            var FilmeSelecionado = db.FILMES.Where(f => f.Id == DadosTela.Sessao.FilmeId).FirstOrDefault();

            if (FilmeSelecionado.emBreve == true)
            {
                FilmeSelecionado.emBreve = false;
                FilmeSelecionado.emCartaz = true;
                db.FILMES.Update(FilmeSelecionado);
            }



            db.SESSOES.Add(DadosTela.Sessao);
            db.SaveChanges();
            return RedirectToAction("ListaSessoes");
        }

        public ActionResult EditarSessao(int id)
        {
            if (User.Identity.IsAuthenticated)
                ViewData["admin"] = User.Identity.Name;

            AdicionarSessaoModel model = new()
            {
                FilmesDisponiveis = db.FILMES.ToList(),
                Sessao = db.SESSOES.Where(a => a.Id == id).FirstOrDefault()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarSessao(AdicionarSessaoModel DadosTela)
        {
            db.SESSOES.Update(DadosTela.Sessao);
            db.SaveChanges();
            return RedirectToAction("ListaSessoes");
        }

        public IActionResult RemoverSessao(int id)
        {
            db.SESSOES.Remove(
                db.SESSOES.Where(a => a.Id == id).FirstOrDefault()
                );
            db.SaveChanges();
            return RedirectToAction("ListaSessoes");
        }

        public IActionResult PaginaInicial()
        {
            ViewData["admin"] = User.Identity.Name;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ListaAdmin()
        {

            return View();
        }
    }
}
