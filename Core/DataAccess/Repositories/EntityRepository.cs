using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using Project.Core.DataAccess.Validations;
using Project.Core.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Project.Core.DataAccess.Repositories
{
    public class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    context.Entry(entity).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                Validator.ValidationErrors(e);
            }
        }

        public int Count()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList().Count;
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return (filter == null ? context.Set<TEntity>().ToList() :
                                     context.Set<TEntity>().Where(filter).ToList());
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
