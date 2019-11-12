using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Fatec.Application.ViewModels
{
    public class PermissaoViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name ="Id")]
        public string IdUsuario { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        public string NomeUsuario { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 10)]
        public string EmailUsuario { get; set; }

        [Required]
        [Display(Name ="Função")]
        [StringLength(25, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 1)]
        public string  Role { get; set; }

        [Required]
        [Display(Name = "Permissão")]
        [StringLength(25, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 1)]
        public Claim Claim { get; set; }
    }
}