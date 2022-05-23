using System.Collections.Generic;
using Projeto_IHC.Entidades;

namespace Projeto_IHC.Models
{
  public class AdicionarSessaoModel
  {
    public List<Filme> FilmesDisponiveis { get; set; }
    public Sessao Sessao { get; set; }
  }
}