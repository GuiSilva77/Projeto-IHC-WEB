using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_IHC.Entidades
{
    public class Sessao
    {
        public int Id { get; set; }

        public Filme Filme = new Filme();

        public DateTime Data = new DateTime();

        public int Sala { get; set; }

        public enum Audio { Dublado, Legendado, DubladoLegenda}

        public Audio Tipo { get; set; }

        public bool is3D { get; set; }

        public Sessao(int id, Filme filme, DateTime data, int sala, Audio tipo, bool is3d)
        {
            Id = id;
            Filme = filme;
            Data = data;
            Sala = sala;
            Tipo = tipo;
            is3D = is3d;
        }
    }
}
