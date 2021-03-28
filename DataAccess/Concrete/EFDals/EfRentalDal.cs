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
                IQueryable<RentalDetailsDto> data = CreateData(context);
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
                IQueryable<RentalDetailsDto> data = CreateData(context);
                #endregion

                return data.FirstOrDefault(filter);
            }
        }

        public Rental GetByCarId(Expression<Func<Rental, bool>> filter)
        {
            using (EfProjectContext context = new EfProjectContext())
            {
                var data = context.Rentals.Where(filter).ToList().LastOrDefault();
                return data;
            }
        }

        private static IQueryable<RentalDetailsDto> CreateData(EfProjectContext context)
        {
            return from rent in context.Rentals
                   join car in context.Cars on rent.CarId equals car.CarId
                   join bra in context.Brands on car.BrandId equals bra.BrandId
                   join cus in context.Customers on rent.CustomerId equals cus.CustomerId
                   join usr in context.Users on cus.UserId equals usr.UserId
                   select new RentalDetailsDto
                   {
                       Id = rent.Id,
                       CarName = bra.BrandName,
                       CustomerFirstName = usr.FirstName,
                       CustomerLastName = usr.LastName,
                       RentDate = rent.RentDate,
                       ReturnDate = rent.ReturnDate
                   };
        }
    }
}
