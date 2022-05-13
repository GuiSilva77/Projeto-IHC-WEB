using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
