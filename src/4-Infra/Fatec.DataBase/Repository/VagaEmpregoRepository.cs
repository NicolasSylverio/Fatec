using Fatec.DataBase.Context;
using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Vagas;
using System.Linq;

namespace Fatec.DataBase.Repository
{
    public class VagaEmpregoRepository : RepositoryBase<VagaEmprego>, IVagaEmpregoRepository
    {
        public VagaEmpregoRepository(IntranetFatecContext context) : base(context)
        {
        }

        public override void Add(VagaEmprego obj)
        {
            var tags = obj.TagsId;

            obj.Tags = Db
                .Tags
                .Where(x => tags.Contains(x.Id))
                .ToList();

            base.Add(obj);
        }
    }
}