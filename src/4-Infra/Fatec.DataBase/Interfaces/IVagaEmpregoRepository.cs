using Fatec.CrossCutting.Models.Vagas;
using System.Collections.Generic;
using Fatec.CrossCutting.Models.PaginacaoHelper;

namespace Fatec.DataBase.Interfaces
{
    public interface IVagaEmpregoRepository : IRepositoryBase<VagaEmprego>
    {
        ResultadoPaginacao<VagaEmprego> GetAll(Paginacao paginacao);

        ResultadoPaginacao<VagaEmprego> GetAllByTituloTags(string titulo, IEnumerable<int> tags, Paginacao paginacao);
    }
}