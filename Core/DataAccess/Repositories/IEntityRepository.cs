﻿using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Core.DataAccess.Repositories
{
    public interface IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(Expression<Func<TEntity, bool>> filter);
        void Update(TEntity entity);
        int Count();
    }
}