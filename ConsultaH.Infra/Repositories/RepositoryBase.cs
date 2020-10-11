using ConsultaH.Domain.Interfaces;
using ConsultaH.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ConsultaH.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {

        protected AppConsultahContext Db = new AppConsultahContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }        

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();            
        }

        public TEntity GetById(int entityId)
        {
            return Db.Set<TEntity>().Find(entityId);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Set<TEntity>().AddOrUpdate(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
