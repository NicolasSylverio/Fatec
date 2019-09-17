using AutoMapper;
using Fatec.Application.ViewModels;
using Fatec.Domain.Models;
using Fatec.Domain.Models.Empresas;
using Fatec.Domain.Models.Vagas;

namespace Fatec.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VagaEstagioViewModel, VagaEstagio>();
            CreateMap<VagaEmpregoViewModel, VagaEmprego>();
            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<TagsViewModel, Tags>();
        }
    }
}