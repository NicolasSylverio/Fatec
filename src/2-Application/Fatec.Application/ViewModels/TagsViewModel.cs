using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class TagsViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nome da Tag")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(16, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 1)]        
        public string Nome { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]        
        [Display(Name = "Descrição da Tag")]
        public string Descricao { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Tag Ativa?")]
        public bool Ativo { get; set; }
    }
}