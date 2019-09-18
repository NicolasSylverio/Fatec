using Fatec.Domain.Models.Empresas;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class VagaEmpregoViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Titulo da Vaga")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Subtitulo da Vaga")]
        public string Subtitulo { get; set; }

        [Required]
        [StringLength(512, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição da Vaga")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail de Contato")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Url da Imagem")]
        public string UrlImagem { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Url do Site")]
        public string UrlSite { get; set; }
    }
}