using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fatec.CrossCutting.Models;
using Fatec.CrossCutting.Helper;
using Fatec.CrossCutting.Models.Empresas;
using System.ComponentModel;

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

        [ReadOnly(true)]
        //[StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail de Contato")]
        public string Email { get; set; }

        [ReadOnly(true)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Url da Imagem")]
        public string UrlImagem { get; set; }

        [ReadOnly(true)]
        //[StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Url)]
        [Display(Name = "Url do Site")]
        public string UrlSite { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Hora de Cadastro")]
        public DateTime DataHoraCadastro { get; set; } = DataHelper.GetHoraBrasilia();

        [DataType(DataType.Date)]
        [Display(Name = "Data de Validade da Vaga")]
        public DateTime DataValidade { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        public Empresa Empresa { get; set; }

        [Display(Name = "Tags")]
        public IEnumerable<int> TagsId { get; set; }

        [Display(Name = "Tags")]
        public IEnumerable<Tags> Tags { get; set; }
    }
}