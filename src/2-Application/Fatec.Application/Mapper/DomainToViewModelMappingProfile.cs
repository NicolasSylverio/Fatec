using AutoMapper;
using Fatec.Application.ViewModels;

namespace Fatec.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Models.Vagas.VagaEstagio, VagaEstagioViewModel>();
        }
    }
}