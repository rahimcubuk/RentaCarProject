using System;
using System.Collections.Generic;
using Project.Core.DataAccess.Repositories;
using Project.DataAccess.Abstract.Dals;
using Project.DataAccess.Concrete.Contexts;
using Project.Entities.Concrete.DTOs;
using Project.Entities.Concrete.Models;
using System.Linq;
using System.Linq.Expressions;
using Project.Core.DataAccess.Validations;
using System.Data.Entity.Validation;

namespace Project.DataAccess.Concrete.EFDals
{
    public class EfCarDal : EntityRepository<Car, EfProjectContext>, ICarDal
    {
        public List<CarDetailsDto> GetAllCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            try
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
            catch (DbEntityValidationException e)
            {
                Validator.ValidationErrors(e);
                throw;
            }
        }
        public CarDetailsDto GetCarDetailsById(Expression<Func<CarDetailsDto, bool>> filter)
        {
            try
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
            catch (DbEntityValidationException e)
            {
                Validator.ValidationErrors(e);
                throw;
            }
        }
    }
}
