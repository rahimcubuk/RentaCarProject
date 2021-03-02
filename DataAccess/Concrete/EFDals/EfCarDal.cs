using Core.DataAccess.Repositories;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EFDals
{
    public class EfCarDal : EntityRepository<Car, EfProjectContext>, ICarDal
    {
        public List<CarDetailsDto> GetAllCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (EfProjectContext context = new EfProjectContext())
            {
                #region Data
                var data = from car in context.Cars
                           join bra in context.Brands on car.BrandId equals bra.BrandId
                           join col in context.Colors on car.ColorId equals col.ColorId
                           select new CarDetailsDto
                           {
                               CarId = car.CarId,
                               CarName = car.CarName,
                               BrandName = bra.BrandName,
                               ColorName = col.ColorName,
                               DailyPrice = car.DailyPrice,
                               ModelYear = car.ModelYear,
                               Description = car.Description
                           };
                #endregion

                return (filter == null ? data.ToList() :
                                     data.Where(filter).ToList());
            }
        }
        public CarDetailsDto GetCarDetailsById(Expression<Func<CarDetailsDto, bool>> filter)
        {
            using (EfProjectContext context = new EfProjectContext())
            {
                #region Data
                var data = from car in context.Cars
                           join bra in context.Brands on car.BrandId equals bra.BrandId
                           join col in context.Colors on car.ColorId equals col.ColorId
                           select new CarDetailsDto
                           {
                               CarId = car.CarId,
                               CarName = car.CarName,
                               BrandName = bra.BrandName,
                               ColorName = col.ColorName,
                               DailyPrice = car.DailyPrice,
                               ModelYear = car.ModelYear,
                               Description = car.Description
                           };
                #endregion

                return data.FirstOrDefault(filter);
            }
        }
    }
}
