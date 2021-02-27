using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Project.Business.Abstract.Repository;
using Project.Entities.Concrete.Models;
using System.Collections.Generic;

namespace Project.Business.Abstract.Services
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
