﻿using Fatec.CrossCutting.Models;
using Fatec.CrossCutting.Models.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Application.ViewModels
{
    public class VagaEmpregoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Titulo da Vaga")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Subtitulo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Subtitulo da Vaga")]
        public string Subtitulo { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(512, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição da Vaga")]
        public string Descricao { get; set; }

        [ReadOnly(true)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail de Contato")]
        public string Email { get; set; }

        [ReadOnly(true)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Url da Imagem")]
        [StringLength(512, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        public string UrlImagem { get; set; }

        [ReadOnly(true)]
        [DataType(DataType.Url)]
        [Display(Name = "Url do Site")]
        public string UrlSite { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Hora de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Validade da Vaga")]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "O campo Empresa é obrigatório.")]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        public Empresa Empresa { get; set; }

        [Display(Name = "Tags")]
        public IEnumerable<int> TagsId { get; set; }

        public IEnumerable<Tags> Tags { get; set; }
    }
}