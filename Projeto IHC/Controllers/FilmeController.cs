﻿using Microsoft.AspNetCore.Mvc;
using Projeto_IHC.Entidades;
using Projeto_IHC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC.Controllers
{
    public class FilmeController : Controller
    {
        public readonly Contexto db;
        public FilmeController(Contexto _db)
        {
            db = _db;
        }

        public IActionResult Index(int id)
        {
            FilmeModel FM = new FilmeModel();
            FM.Filme = db.FILMES.Where(a => a.Id == id).FirstOrDefault();
            return View(FM);
        }
    }
}
