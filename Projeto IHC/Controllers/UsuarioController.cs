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

            ViewData["admin"] = UsuarioLogado.Nome;

            //get return url from query string
            string returnUrl = HttpContext.Request.Query["returnUrl"];
            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Admin");
            else
                return Redirect(returnUrl);
        }

        public async Task<IActionResult> Sair()
        {
            string NomeUsuario = HttpContext.User.Identity.Name;

            Entidades.Usuario UsuarioLogado = db.USUARIOS.Where(a => a.Nome == NomeUsuario).FirstOrDefault();
            UsuarioLogado.UltimaVezOnline = DateTime.Now;
            db.USUARIOS.Update(UsuarioLogado);
            db.SaveChanges();

            ViewData["admin"] = null;

            await HttpContext.SignOutAsync("CookieAuthentication");
            ViewData["ReturnUrl"] = "/";
            return Redirect(ViewData["ReturnUrl"].ToString());
        }

        public IActionResult Redefinir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Redefinir(string chave)
        {
            var chaveMestra = "123456789";
            if (chave == null || chave != chaveMestra)
            {
                TempData["Error"] = "Chave Inválida.";
                return View();
            }

            return RedirectToAction("RedefinirSenha");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RedefinirSenha(string usuario, string senha)
        {
            if (string.IsNullOrEmpty(senha))
            {
                TempData["Error"] = "O(s) Campo(s) não pode(m) estar vazio(s).";
                return View();
            }

            Entidades.Usuario UsuarioLogado = db.USUARIOS.Where(a => a.Email == usuario).FirstOrDefault();
            UsuarioLogado.Senha = senha;

            db.USUARIOS.Update(UsuarioLogado);
            db.SaveChanges();

            TempData["Success"] = "Senha Redefinida com Sucesso.";
            return RedirectToAction("Entrar");
        }
    }
}
