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
    public class EfRentalDal : EntityRepository<Rental, EfProjectContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetAllRentDetails(Expression<Func<RentalDetailsDto, bool>> filter = null)
        {
            try
            {
                using (EfProjectContext context = new EfProjectContext())
                {
                    #region Data
                    var data = from rent in context.Rentals
                               join car in context.Cars on rent.CarId equals car.CarId
                               join cus in context.Customers on rent.CustomerId equals cus.CustomerId
                               join usr in context.Users on cus.UserId equals usr.UserId
                               select new RentalDetailsDto
                               {
                                   Id = rent.Id,
                                   CarName = car.CarName,
                                   CustomerName = usr.FirstName,
                                   RentDate = rent.RentDate,
                                   ReturnDate = rent.ReturnDate
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

        public RentalDetailsDto GetRentDetailsById(Expression<Func<RentalDetailsDto, bool>> filter)
        {
            try
            {
                using (EfProjectContext context = new EfProjectContext())
                {
                    #region Data
                    var data = from rent in context.Rentals
                               join car in context.Cars on rent.CarId equals car.CarId
                               join cus in context.Customers on rent.CustomerId equals cus.CustomerId
                               join usr in context.Users on cus.UserId equals usr.UserId
                               select new RentalDetailsDto
                               {
                                   Id = rent.Id,
                                   CarName = car.CarName,
                                   CustomerName = usr.FirstName,
                                   RentDate = rent.RentDate,
                                   ReturnDate = rent.ReturnDate
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
