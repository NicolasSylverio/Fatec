﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fatec.CrossCutting.Models.Vagas;
using Fatec.DataBase.Context;
using Fatec.DataBase.Interfaces;

namespace Fatec.DataBase.Repository
{
    public class VagaEstagioRepository : IVagaEstagioRepository
    {
        private readonly IntranetFatecContext Db;

        public VagaEstagioRepository(IntranetFatecContext context)
        {
            Db = context;
        }

        public void Add(VagaEstagio obj)
        {
            Db.Set<VagaEstagio>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<VagaEstagio> GetAll()
        {
            return Db.VagaEstagio
                .ToList();
        }

        public VagaEstagio GetById(int id)  
        {
            return Db.Set<VagaEstagio>()
                .Find(id);
        }

        public void Remove(VagaEstagio obj)
        {
            Db.Entry(obj).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public void Remove(int obj)
        {
            throw new NotImplementedException();
        }

        public void Update(VagaEstagio obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}