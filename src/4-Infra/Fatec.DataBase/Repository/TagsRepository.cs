using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Tags;
using Fatec.Infra.DataBase.Context;
using Fatec.Infra.DataBase.Repositories;
using System.Data.Entity;

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