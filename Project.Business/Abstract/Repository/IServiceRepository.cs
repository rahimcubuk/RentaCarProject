﻿using Project.Core.Entities;
using Project.Core.Utilities.Results.Abstract;
using Project.Core.Utilities.Results.Concrete;
using System.Collections.Generic;

namespace Project.Business.Abstract.Repository
{
    public interface IServiceRepository<TEntity> where TEntity : class, IEntity, new()
    {
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
        IDataResult<List<TEntity>> GetAll();
        IDataResult<TEntity> GetById(int id);
    }
}