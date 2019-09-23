using System.Collections.Generic;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.Empresas;

namespace Fatec.Application.Interface
{
    public interface IEmpresaAppService : IAppServiceBase<Empresa> 
    {
        void Cadastrar(EmpresaViewModel empresaViewModel);

        IEnumerable<EmpresaViewModel> GetAllEmpresaViewModel();
        EmpresaViewModel GetViewModel(int id);
        void Alterar(EmpresaViewModel model);
    }
}