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
        public Filme Filme = new Filme();
        public DateTime Data = new DateTime();
        public int Sala { get; set; }
        public enum Audio { Dublado, Legendado, DubladoLegenda}
        public Audio Tipo { get; set; }
        public enum Video { V3D, V2D, IMAX}
        public Video VideoTipo { get; set; }

        public Sessao()
        {

        }

        public Sessao(int id, Filme filme, DateTime data, int sala, Audio tipo, Video is3d)
        {
            Id = id;
            Filme = filme;
            Data = data;
            Sala = sala;
            Tipo = tipo;
            VideoTipo = is3d;
        }

        public Sessao(int i)
        {
            Id = 1;
            Filme = new Filme(1);
            Data = new DateTime(2022, 04, 30, 18, 30, 00);
            Sala = 1;
            Tipo = Sessao.Audio.Dublado;
            VideoTipo = Sessao.Video.V2D;
        }

    }
}