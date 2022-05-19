using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_IHC.Models;
using Projeto_IHC.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC.Controllers
{
    public class HomeController : Controller
    {
        public readonly Contexto db;
        public HomeController(Contexto _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            HomeModel HM = new HomeModel();
            HM.FilmeDestaque = db.FILMES.Where(a => a.emCartaz == true).FirstOrDefault();
            HM.filmesEmBreve = db.FILMES.Where(a => a.emBreve == true).ToList();
            return View(HM);
        }

        public IActionResult Programacao()
        {
            ProgramacaoModel PM = new ProgramacaoModel();
            PM.Sessoes = db.SESSOES.ToList();
            foreach (var item in PM.Sessoes)
                item.Filme = db.FILMES.Where(a => a.Id == item.FilmeId).FirstOrDefault();

            return View(PM);
        }

        public IActionResult SobreNos()
        {
            return View();
        }

        public IActionResult AddSessao()
        {
            Sessao sessao = new Sessao();

            sessao.Filme = db.FILMES.Where(a => a.emCartaz == true).FirstOrDefault();
            sessao.FilmeId = sessao.Filme.Id;
            sessao.Horario = "18:30";
            sessao.DiasSemana = "1111111";
            sessao.Sala = 1;
            sessao.Audio = "Dublado";
            sessao.Video = "2D";

            db.SESSOES.Add(sessao);
            db.SaveChanges();

            return RedirectToAction("Programacao");
        }
    }
}
