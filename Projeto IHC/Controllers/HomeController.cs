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
            for (int i = 0; i < 5; i++)
            {
                HM.filmesEmBreve.Add(db.FILMES.Where(a => a.Id == 1).FirstOrDefault());
                HM.filmesEmCartaz.Add(db.FILMES.Where(a => a.Id == 1).FirstOrDefault());
            }
            return View(HM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
