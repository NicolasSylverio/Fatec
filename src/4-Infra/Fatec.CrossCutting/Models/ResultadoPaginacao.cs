using System;
using System.Collections.Generic;

namespace Fatec.CrossCutting.Models
{
    public class ResultadoPaginacao<T> where T : class
    {
        public ResultadoPaginacao()
        {
            //
        }

        public ResultadoPaginacao(IList<T> resultados, int total, int pagina, int totalPagina)
        {
            Resultados = resultados;
            Pagina = pagina;
            Total = total;
            TotalPorPagina = totalPagina;
            TotalPaginas = (int)Math.Ceiling((double)Total / TotalPorPagina);
        }

        public ResultadoPaginacao(IList<T> resultados, int total, int pagina, int totalPagina, string ordenarPor, string direcao)
        {
            Resultados = resultados;
            Pagina = pagina;
            Total = total;
            TotalPorPagina = totalPagina;
            TotalPaginas = (int)Math.Ceiling((double)Total / TotalPorPagina);
            OrdenarPor = ordenarPor;
            Direcao = direcao;
        }

        public int Total { get; set; }
        public int Pagina { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalPorPagina { get; set; }
        public string OrdenarPor { get; set; }
        public string Direcao { get; set; }

        public IList<T> Resultados { get; set; }
    }
}