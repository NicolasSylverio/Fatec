using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Tags;
using Fatec.Infra.DataBase.Context;
using Fatec.Infra.DataBase.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Fatec.DataBase.Repository
{
    public class TagsRepository : RepositoryBase<Tags>, ITagsRepository
    {
        public TagsRepository(IntranetFatecContext context) : base(context)
        {
        }

        public override void Remove(Tags obj)
        {
            Db.Entry(obj).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public override void Add(Tags obj)
        {
            Db.Set<Tags>().Add(obj);
            Db.SaveChanges();
        }

        public override IEnumerable<Tags> GetAll()
        {
            return Db.Tags
                .ToList();
        }

        public override Tags GetById(int id)
        {
            return Db.Set<Tags>()
                .Find(id);
        }

        public override void Update(Tags obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

    }
}