using Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Abstract.Services
{
    public interface IRentalService : IServiceRepository<Rental>
    {
        IDataResult<List<RentalDetailsDto>> GetRentalDetails();
        IDataResult<RentalDetailsDto> GetRentalDetailById(int id);
        IDataResult<Rental> GetByCarId(int id);
    }
}
