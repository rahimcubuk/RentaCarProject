using Core.Entities;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract.Repository
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
