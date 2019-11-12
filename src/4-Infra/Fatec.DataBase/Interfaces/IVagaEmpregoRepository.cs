using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.CrossCutting.Models.Vagas;

namespace Fatec.DataBase.Interfaces
{
    public interface IVagaEmpregoRepository : IRepositoryBase<VagaEmprego>
    {
        ResultadoPaginacao<VagaEmprego> GetAll(Paginacao paginacao);

        ResultadoPaginacao<VagaEmprego> GetAllByTituloTags(string titulo, int tags, Paginacao paginacao);
    }
}