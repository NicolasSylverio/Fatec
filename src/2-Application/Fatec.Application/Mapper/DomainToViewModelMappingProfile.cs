using AutoMapper;
using Fatec.Application.ViewModels;
using Fatec.Domain.Models.Empresas;
using Fatec.Domain.Models.Tags;
using Fatec.Domain.Models.Vagas;

namespace Fatec.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<VagaEstagio, VagaEstagioViewModel>();
            CreateMap<VagaEmprego, VagaEmpregoViewModel>();
            CreateMap<Tags, TagsViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
        }
    }
}