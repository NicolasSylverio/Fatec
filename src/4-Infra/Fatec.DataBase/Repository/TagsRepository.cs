using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models;
using System.Data.Entity;
using Fatec.DataBase.Context;

namespace Fatec.DataBase.Repository
{
    public class TagsRepository : RepositoryBase<Tags>, ITagsRepository
    {
        public TagsRepository(IntranetFatecContext context) : base(context)
        {
        }

        public override void Update(Tags obj)
        {
            var objeto = Db.Set<Tags>().Find(obj.Id);

            objeto.Nome = obj.Nome;
            objeto.Descricao = obj.Descricao;
            objeto.Ativo = obj.Ativo;

            Db.Entry(objeto).State = EntityState.Modified;
            Db.SaveChanges();
        }

    }
}