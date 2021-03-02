using Core.DataAccess.Repositories;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Dals
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailsDto> GetAllRentDetails(Expression<Func<RentalDetailsDto, bool>> filter = null);
        RentalDetailsDto GetRentDetailsById(Expression<Func<RentalDetailsDto, bool>> filter);
    }
}
