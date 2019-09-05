using Fatec.Application.ViewModels;
using System.Collections.Generic;

namespace Fatec.Application.Interface
{
    public interface IVagaEmpregoAppService
    {
        void Cadastrar(VagaEmpregoViewModel vagaEstagioViewModel);

        IEnumerable<VagaEmpregoViewModel> GetAllVagaEmpregoViewModel();
    }
}