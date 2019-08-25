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
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(IntranetFatecContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}