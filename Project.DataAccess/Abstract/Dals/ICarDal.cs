using Core.DataAccess.Repositories;
using Project.Entities.Concrete.DTOs;
using Project.Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.DataAccess.Abstract.Dals
{
    public interface ICarDal : IEntityRepository<Car>
    {
        CarDetailsDto GetCarDetailsById(Expression<Func<CarDetailsDto, bool>> filter);
        List<CarDetailsDto> GetAllCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null);
    }
}
