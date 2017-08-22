using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApi.Entity;

namespace WebApi.Repository
{
    public class GenericRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        private readonly BillingDbContext billingDbContext;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(BillingDbContext billingDbContext)
        {
            this.billingDbContext = billingDbContext;
            this.dbSet = billingDbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return this.dbSet;
        }

        public TEntity Get(TId id)
        {
            var entity = GetSingle(id);
            return entity;
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
            this.billingDbContext.SaveChanges();
        }

        public void Update(TId id, TEntity entity)
        {
            var originalEntity = GetSingle(id);
            originalEntity = Mapper.Map(entity, originalEntity);

            this.dbSet.Update(originalEntity);
            this.billingDbContext.SaveChanges();
        }

        public void Delete(TId id)
        {
            var entity = GetSingle(id);
            this.dbSet.Remove(entity);
            this.billingDbContext.SaveChanges();
        }

        private TEntity GetSingle(TId id)
        {
            var entity = this.dbSet.Find(id);
            return entity;
        }
    }
}
