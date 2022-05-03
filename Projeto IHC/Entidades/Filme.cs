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
        public string Diretor { get; set; }
        public string Ano { get; set; }
        public string Resumo { get; set; }

        public Filme() { }

        public Filme(int id,string nome,string urlImagem,string ano, string diretor, string resumo)
        {
            Id = id;
            Nome = nome;
            UrlImagem = urlImagem;
            Diretor = diretor;
            Ano = ano;
            Resumo = resumo;
        }

        public Filme(int i)
        {
            Id = 550;
            Nome = "Clube da Luta";
            UrlImagem = "https://image.tmdb.org/t/p/w500/r3pPehX4ik8NLYPpbDRAh0YRtMb.jpg"; 
            Ano = "1999";
            Diretor = "Ridley Scott"; 
            Resumo = "Um homem deprimido que sofre de insônia conhece um estranho vendedor de sabonetes chamado Tyler Durden. Eles formam um clube clandestino com regras rígidas onde lutam com outros homens cansados de suas vidas mundanas. Mas sua parceria perfeita é comprometida quando Marla chama a atenção de Tyler.";
        }

    }
}
