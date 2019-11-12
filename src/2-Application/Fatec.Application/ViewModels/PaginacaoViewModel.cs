using Fatec.CrossCutting.Constants;
using System.Collections.Generic;

namespace Fatec.Application.ViewModels
{
    public class PaginacaoViewModel<T> where T : class
    {
        public IEnumerable<T> Resultado { get; set; }


        public int Pagina { get; set; } = 1;
        public int TotalPorPagina { get; set; } = Constants.NumeroVagasPorPagina;
        public string OrdenarPor { get; set; }
        public string Direcao { get; set; }
        public int Total { get; set; } = 0;

        public int ExibindoDe(int totalItens)
        {
            return totalItens == 0 ? 0 : 1 + TotalPorPagina * (Pagina - 1);
        }

        public int ExibindoAte(int totalItens)
        {
            return TotalPorPagina * Pagina < totalItens ? TotalPorPagina * Pagina : totalItens;
        }
    }
}