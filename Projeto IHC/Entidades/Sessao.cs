using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_IHC.Entidades;

namespace Projeto_IHC.Entidades
{
    public class Sessao
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public DateTime Data { get; set; }
        public int Sala { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
    }
}