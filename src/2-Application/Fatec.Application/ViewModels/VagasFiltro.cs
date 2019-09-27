using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class VagasFiltro
    {
        public VagasFiltro()
        {
            
        }

        public VagasFiltro(string pesquisaTitulo, IEnumerable<int> tags)
        {
            PesquisaTitulo = pesquisaTitulo;
            Tags = tags;
        }

        [StringLength(20, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Pesquisa")]
        public string PesquisaTitulo { get; set; } = string.Empty;

        [Display(Name = "Tags")]
        public IEnumerable<int> Tags { get; set; } = new List<int>();
    }
}
