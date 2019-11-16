using Fatec.CrossCutting.Models;
using System.Data.Entity;
using Fatec.DataBase.Context;

using Fatec.DataBase.Interfaces;
using Fatec.CrossCutting.Helper;

namespace Fatec.DataBase.Repository
{
    public class TagsRepository : RepositoryBase<Tags>, ITagsRepository
    {
        public TagsRepository(IntranetFatecContext context) 
            : base(context)
        {
        }

        public override void Add(Tags obj)
        {
            obj.DataCadastro = DataHelper.GetHoraBrasilia();

            base.Add(obj);
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