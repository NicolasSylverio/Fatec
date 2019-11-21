using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nome da Empresa")]
        [Required(ErrorMessage = "O campo Nome da Empresa é obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(14, ErrorMessage = "O {0} deve ter no mínimo {2} caracteres.", MinimumLength = 7)]
        public string Telefone { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Site da Empresa")]
        [Required(ErrorMessage = "O campo Site da Empresa é obrigatório.")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
        public string UrlSite { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}