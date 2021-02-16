using Project.Core.DataAccess.Repositories;
using Project.Entities.Concrete.DTOs;
using Project.Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Abstract.Dals
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailsDto> GetAllRentDetails(Expression<Func<RentalDetailsDto, bool>> filter = null);
        RentalDetailsDto GetRentDetailsById(Expression<Func<RentalDetailsDto, bool>> filter);
    }
}
