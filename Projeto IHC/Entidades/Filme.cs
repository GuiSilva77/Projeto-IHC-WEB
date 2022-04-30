using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC.Entidades
{
    public class Filme
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string UrlImagem { get; set; }
    
        public Filme() { }

        public Filme(int id,string nome,string urlImagem)
        {
            Id = id;
            Nome = nome;
            UrlImagem = urlImagem;
        }

    }
}
