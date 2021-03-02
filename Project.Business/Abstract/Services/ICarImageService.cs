using Core.Utilities.Results.Abstract;
using Entities.Concrete.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract.Services
{
    public interface ICarImageService// : IServiceRepository<CarImage>
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int id);
        IResult Add(IFormFile image, CarImage entity);
        IResult Update(IFormFile image, CarImage entity);
        IResult Delete(CarImage entity);
    }
}
