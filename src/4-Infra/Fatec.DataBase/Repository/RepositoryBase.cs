using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fatec.DataBase.Context;
using Fatec.Domain.Interfaces.Repositories;

namespace Fatec.DataBase.Repository
{

    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IntranetFatecContext Db;

        public RepositoryBase(IntranetFatecContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
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