using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC.Models
{
    public class HomeModel
    {
        public List<Entidades.Filme> filmesEmCartaz = new List<Entidades.Filme>();
        public List<Entidades.Filme> filmesEmBreve = new List<Entidades.Filme>();
        public List<Entidades.Sessao> Sessoes = new List<Entidades.Sessao>();
    }
}
