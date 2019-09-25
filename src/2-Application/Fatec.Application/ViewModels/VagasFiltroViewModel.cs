using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class VagasFiltroViewModel<T> where T : class
    {
        public IEnumerable<T> Objeto { get; set; }

        [StringLength(20, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Pesquisa")]
        public string Pesquisa { get; set; }

        [Display(Name = "Tags")]
        public IEnumerable<int> Tags { get; set; }
    }
}