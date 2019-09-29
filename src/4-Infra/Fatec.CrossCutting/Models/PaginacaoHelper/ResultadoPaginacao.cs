using System;
using System.Collections.Generic;

namespace Fatec.CrossCutting.Models.PaginacaoHelper
{
    public sealed class ResultadoPaginacao<T> where T : class
    {
        public ResultadoPaginacao()
        {
            //
        }

        public ResultadoPaginacao(IEnumerable<T> resultados, int total, int pagina, int totalPagina)
        {
            Resultados = resultados;
            Pagina = pagina;
            Total = total;
            TotalPorPagina = totalPagina;
            TotalPaginas = (int)Math.Ceiling((double)Total / TotalPorPagina);
        }

        public ResultadoPaginacao(IEnumerable<T> resultados, int total, int pagina, int totalPagina, string ordenarPor, string direcao)
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

        public IEnumerable<T> Resultados { get; set; }
    }
}