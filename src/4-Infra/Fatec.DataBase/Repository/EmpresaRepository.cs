using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fatec.DataBase.Context;
using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Empresas;

namespace Fatec.DataBase.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IntranetFatecContext Db;

        public EmpresaRepository(IntranetFatecContext context)
        {
            Db = context;
        }

        public void Add(Empresa obj)
        {
            Db.Set<Empresa>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Empresa> GetAll()
        {
            return Db.Empresa
                .ToList();
        }

        public Empresa GetById(int id)  
        {
            return Db.Set<Empresa>()
                .Find(id);
        }

        public void Remove(int id)
        {
            var obj = Db.Set<Empresa>().Find(id);
            Db.Entry(obj).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public void Update(Empresa obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Update(int obj)
        {
            throw new NotImplementedException();
        }
    }
}