using Core.DataAccess.Repositories;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Dals
{
    public interface ICarDal : IEntityRepository<Car>
    {
        CarDetailsDto GetCarDetailsById(Expression<Func<CarDetailsDto, bool>> filter);
        List<CarDetailsDto> GetAllCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null);
    }
}
