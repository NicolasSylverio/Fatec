using Fatec.CrossCutting.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome da Empresa")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(14, ErrorMessage = "O {0} deve ter no mínimo {2} caracteres.", MinimumLength = 7)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.Url)]
        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
        [Display(Name = "Endereço URl do site da empresa")]
        public string UrlSite { get; set; }

        public DateTime DataHoraCadastro { get; set; } = DataHelper.GetHoraBrasilia();

    }
}