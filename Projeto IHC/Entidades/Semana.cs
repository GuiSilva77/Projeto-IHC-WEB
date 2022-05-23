using System.Collections.Generic;

namespace Projeto_IHC.Entidades
{
    public class Semana
    {
        //criar uma lista de dias da semana

        public List<bool> DiasSemana { get; set; }

        public Semana()
        {
            for (int i = 0; i < 7; i++)
            {
                DiasSemana.Add(false);
            }
        }

        public Semana(string diasSemana)
        {
            //separar string em um array de char separada por nada
            char[] separador = { ',' };
            string[] dias = diasSemana.Split(separador);

            foreach (var dia in dias)
            {
                switch (dia)
                {
                    case "1":
                        DiasSemana.Add(true);
                        break;
                    case "0":
                        DiasSemana.Add(false);
                        break;
                }
            }
        }
    }
}