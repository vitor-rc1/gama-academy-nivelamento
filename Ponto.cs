using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Ponto
    {
        public int Id { get; private set; }
        public DateTime Entrada { get; private set; }
        public DateTime Saida { get; private set; }

        public TimeSpan TotalTrabalhado { get; private set; }

        private TimeSpan CalularHorasTrabalhadas(DateTime entrada, DateTime saida)
        {
            return saida - entrada;
        }

        public Ponto(int id, string data, string entrada, string saida)
        {
            Id = id;

            CultureInfo cultureInfo = new CultureInfo("pt-BR");

            Entrada = DateTime.Parse($"{data} {entrada}", cultureInfo);
            Saida = DateTime.Parse($"{data} {saida}", cultureInfo);

            TotalTrabalhado = CalularHorasTrabalhadas(Entrada, Saida);

        }

    }
}
