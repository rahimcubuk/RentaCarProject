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
    public class EfRentalDal : EntityRepository<Rental, EfProjectContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetAllRentDetails(Expression<Func<RentalDetailsDto, bool>> filter = null)
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

        public RentalDetailsDto GetRentDetailsById(Expression<Func<RentalDetailsDto, bool>> filter)
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
    }
}
