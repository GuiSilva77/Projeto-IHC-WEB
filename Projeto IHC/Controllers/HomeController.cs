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
        public IActionResult Index()
        {
            HomeModel filmes = new HomeModel();
            filmes.filmesEmCartaz = new List<Filme>();
            filmes.filmesEmCartaz = new List<Filme>();
            filmes.Sessoes = new List<Sessao>(1);

           for (int i = 0; i < 5; i++)
            {
                Filme filme = new Filme(1);
                filmes.filmesEmCartaz.Add(filme);
                filmes.filmesEmBreve.Add(filme);
            }
            return View(filmes);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
