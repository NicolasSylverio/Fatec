using Fatec.Domain.Interfaces.Repositories;
using Fatec.Infra.DataBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Fatec.Infra.DataBase.Repositories
{

    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IntranetFatecContext Db;

        public RepositoryBase(IntranetFatecContext context)
        {
            Db = context;
        }

        public virtual void Add(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Added;
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual void Remove(int id)
        {
            var obj = Db.Set<TEntity>().Find(id);
            Db.Entry(obj).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}