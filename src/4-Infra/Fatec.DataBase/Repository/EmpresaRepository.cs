﻿using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Empresas;
using Fatec.Infra.DataBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.Infra.Data.Repositories
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

        public void Remove(Empresa obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            Db.SaveChanges();
        }

        public void Update(Empresa obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }
    }
}