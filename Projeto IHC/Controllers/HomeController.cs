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
        public Filme GetFilme()
        {
            return new Filme(1, "Flash", "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/lJA2RCMfsWoskqlQhXPSLFQGXEJ.jpg");
        }

        public HomeModel GenerateContent()
        {
            HomeModel conteudo = new HomeModel();

            conteudo.filmesEmCartaz.Add(GetFilme());
            conteudo.filmesEmCartaz.Add(GetFilme());

            conteudo.filmesEmBreve.Add(GetFilme());
            conteudo.filmesEmBreve.Add(GetFilme());


            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 04, 30, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, true));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 04, 30, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, true));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 04, 30, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, true));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 05, 1, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, false));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 05, 1, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, false));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 05, 1, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, true));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 05, 2, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, true));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 05, 1, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, true));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 05, 2, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, false));
            conteudo.Sessoes.Add(new Sessao(1, GetFilme(), new DateTime(2022, 05, 2, 18, 30, 00, DateTimeKind.Local), 1, Sessao.Audio.Dublado, false));



            return conteudo;
        }

        public IActionResult Index()
        {
            HomeModel filmes = GenerateContent();
            return View(filmes);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
