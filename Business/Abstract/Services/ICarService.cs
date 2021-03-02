using Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Abstract.Services
{
    public interface ICarService : IServiceRepository<Car>
    {
        IDataResult<CarDetailsDto> GetCarDetailById(int id);
        IDataResult<List<CarDetailsDto>> GetCarsDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
    }
}
