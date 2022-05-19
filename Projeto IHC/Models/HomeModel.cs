using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC.Models
{
    public class HomeModel
    { 
        public Entidades.Filme FilmeDestaque { get; set; }
        public List<Entidades.Filme> filmesEmBreve = new List<Entidades.Filme>();
    }
}
