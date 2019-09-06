using System.Collections.Generic;
using Fatec.Application.ViewModels;
using Fatec.Domain.Models.Empresas;

namespace Fatec.Application.Interface
{
    public interface IEmpresaAppService : IAppServiceBase<Empresa> 
    {
        void Cadastrar(EmpresaViewModel empresaViewModel);

        IEnumerable<EmpresaViewModel> GetAllEmpresaViewModel();
    }
}