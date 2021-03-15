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
        IDataResult<List<CarDetailsDto>> GetCarsByBrand(string brand);
        IDataResult<List<CarDetailsDto>> GetCarsByColor(string color);
    }
}
