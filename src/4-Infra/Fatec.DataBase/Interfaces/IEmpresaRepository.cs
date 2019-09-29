using Fatec.CrossCutting.Models.Empresas;
using Fatec.CrossCutting.Models.PaginacaoHelper;

namespace Fatec.DataBase.Interfaces
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        ResultadoPaginacao<Empresa> GetAll(Paginacao paginacao);
    }
}