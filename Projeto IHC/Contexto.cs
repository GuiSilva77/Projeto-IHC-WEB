using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> opt): base(opt)
        { }

        public DbSet<Entidades.Filme> FILMES { get; set; }
        public DbSet<Entidades.Sessao> SESSOES { get; set; }
        public DbSet<Entidades.Usuario> USUARIOS { get; set; }
    }
}
