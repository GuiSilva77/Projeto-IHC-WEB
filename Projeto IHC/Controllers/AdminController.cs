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
            return View();
        }

        public IActionResult ListaFilmes()
        {
            return View(db.FILMES.ToList());
        }

        public IActionResult ListaSessoes()
        {
            var sessoes = new List<Entidades.Sessao>(db.SESSOES.ToList());

            foreach (var sessao in sessoes)
            {
                sessao.Filme = db.FILMES.FirstOrDefault(f => f.Id == sessao.FilmeId);
            }
            return View(sessoes);
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
        public IActionResult EditarFilme(Entidades.Filme DadosTela)
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
    }
}
