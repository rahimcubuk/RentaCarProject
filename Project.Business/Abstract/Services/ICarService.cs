using Project.Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Project.Entities.Concrete.DTOs;
using Project.Entities.Concrete.Models;
using System.Collections.Generic;

namespace Project.Business.Abstract.Services
{
    public interface ICarService : IServiceRepository<Car>
    {
        IDataResult<CarDetailsDto> GetCarDetailById(int id);
        IDataResult<List<CarDetailsDto>> GetCarsDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
    }
}
