using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC.Controllers
{
    public class FilmeController : Controller
    {
        public IActionResult Index(int Id)
        {
            Models.FilmeModel filme = new Models.FilmeModel();
            filme.Filme = new Entidades.Filme(1);
            return View(filme);
        }
    }
}
