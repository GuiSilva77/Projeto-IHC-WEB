using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public readonly IHttpClientFactory HttpClientFactory;
        public readonly Contexto db;
        public AdminController(IHttpClientFactory _httpClientFactory, Contexto _db)
        {
            HttpClientFactory = _httpClientFactory;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
