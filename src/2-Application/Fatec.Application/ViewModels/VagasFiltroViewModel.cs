using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fatec.CrossCutting.Models.PaginacaoHelper;

namespace Fatec.Application.ViewModels
{
    public class VagasFiltroViewModel<T> where T : class
    {
        [StringLength(20, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Pesquisa")]
        public string PesquisaTitulo { get; set; }

        [Display(Name = "Tags")]
        public IEnumerable<int> Tags { get; set; }

        public ResultadoPaginacao<T> Objeto { get; set; }
    }
}