using System.Security.Claims;

namespace Fatec.Application.ViewModels
{
    public class PermissaoViewModel
    {
        public string IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }

        public string  Role { get; set; }
        public Claim Claim { get; set; }
    }
}