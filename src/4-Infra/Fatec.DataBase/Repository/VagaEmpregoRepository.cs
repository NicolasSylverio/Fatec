using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Vagas;
using Fatec.Infra.DataBase.Context;
using Fatec.Infra.DataBase.Repositories;

namespace Fatec.DataBase.Repository
{
    public class VagaEmpregoRepository : RepositoryBase<VagaEmprego>, IVagaEmpregoRepository
    {
        public VagaEmpregoRepository(IntranetFatecContext context) : base(context)
        {
        }
    }
}