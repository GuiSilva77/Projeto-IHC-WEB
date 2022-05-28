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
    public string URLPoster { get; set; }
    public string URLCapa { get; set; }
    public string URLTrailer { get; set; }
    public string Diretor { get; set; }
    public string Ano { get; set; }
    public string Resumo { get; set; }
    public bool emCartaz { get; set; }
    public bool emBreve { get; set; }
    public string Classificacao { get; set; }
    public string Duracao { get; set; }

    
  }
}
