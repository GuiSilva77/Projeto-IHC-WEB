using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projeto_IHC.Controllers
{
    public class UsuarioController : Controller
    {
        public readonly Contexto db;

        public UsuarioController(Contexto _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Entrar");
        }

        public IActionResult Entrar()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Entrar(string login, string senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                TempData["Error"] = "O(s) Campo(s) não pode(m) estar vazio(s).";
                return View();
            }

            Entidades.Usuario UsuarioLogado = db.USUARIOS.Where(a =>
            a.Email == login && a.Senha == senha).FirstOrDefault();
            
            if (UsuarioLogado == null)
            {
                TempData["Error"] = "Usuário e/ou Senha Inválidos.";
                return View();
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, UsuarioLogado.Nome));
            claims.Add(new Claim(ClaimTypes.Sid, UsuarioLogado.Id.ToString()));

            var userIdentity = new ClaimsIdentity(claims, "Acesso");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync("CookieAuthentication",
                principal, new AuthenticationProperties()
                );

            UsuarioLogado.UltimaVezOnline = DateTime.Now;
            db.USUARIOS.Update(UsuarioLogado);
            db.SaveChanges();

            ViewBag.UserName = UsuarioLogado.Nome;

            return Redirect("/Admin/");
        }

        public async Task<IActionResult> Sair()
        {
            string NomeUsuario = HttpContext.User.Identity.Name;

            Entidades.Usuario UsuarioLogado = db.USUARIOS.Where(a => a.Nome == NomeUsuario).FirstOrDefault();
            UsuarioLogado.UltimaVezOnline = DateTime.Now;
            db.USUARIOS.Update(UsuarioLogado);
            db.SaveChanges();

            ViewBag.Username = null;

            await HttpContext.SignOutAsync("CookieAuthentication");
            ViewData["ReturnUrl"] = "/";
            return Redirect("/Usuario/Entrar");
        }

    }
}
