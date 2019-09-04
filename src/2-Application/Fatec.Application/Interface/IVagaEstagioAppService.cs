using System.Collections.Generic;
using Fatec.Domain.Models.Vagas;
using Fatec.Application.ViewModels;

namespace Fatec.Application.Interface
{
    public interface IVagaEstagioAppService : IAppServiceBase<VagaEstagio> 
    {
        void Cadastrar(VagaEstagioViewModel vagaEstagioViewModel);

        IEnumerable<VagaEstagioViewModel> GetAllVagaEstagioViewModel();
    }
}