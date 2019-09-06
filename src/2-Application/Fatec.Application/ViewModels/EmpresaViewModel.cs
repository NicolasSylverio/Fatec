using System;

namespace Fatec.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string UrlSite { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}