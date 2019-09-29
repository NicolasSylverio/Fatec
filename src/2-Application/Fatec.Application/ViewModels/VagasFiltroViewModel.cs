using Fatec.CrossCutting.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class VagasFiltroViewModel<T> where T : class
    {
        public IEnumerable<T> Resultado { get; set; }

        [StringLength(20, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Pesquisa")]
        public string PesquisaTitulo { get; set; } = string.Empty;

        [Display(Name = "Tags")]
        public int Tags { get; set; }

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