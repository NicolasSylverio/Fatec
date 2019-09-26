using Fatec.CrossCutting.Models.Vagas;
using Fatec.DataBase.Context;
using Fatec.DataBase.Interfaces;
using System;
using System.Collections.Generic;
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

        public IEnumerable<VagaEmprego> GetAllByTituloTags(string titulo, IEnumerable<int> tags)
        {
            var query = Db.VagaEmprego.Where(x => x.DataValidade < DateTime.Now);

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                query = query.Where(x => x.Titulo.ToLower().Contains(titulo));
            }

            if (tags != null && tags.Any())
            {
                query = query.Where(x => x.Tags.Any(a => tags.Contains(a.Id)));
            }

            return query.ToList();
        }
    }
}