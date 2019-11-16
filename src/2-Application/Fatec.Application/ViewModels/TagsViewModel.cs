using Fatec.CrossCutting.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class TagsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome da Tag")]
        public string Nome { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição da Tag")]
        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }

        [Display(Name = "Tag")]
        public bool Ativo { get; set; }
    }
}