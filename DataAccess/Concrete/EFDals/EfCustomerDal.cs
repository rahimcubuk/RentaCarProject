﻿using Core.DataAccess.Repositories;
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
    public class EfCustomerDal : EntityRepository<Customer, EfProjectContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetAllCustomerDetails(Expression<Func<CustomerDetailsDto, bool>> filter = null)
        {
            using (EfProjectContext context = new EfProjectContext())
            {
                #region Data
                var data = from c in context.Customers
                           join u in context.Users on c.UserId equals u.UserId
                           select new CustomerDetailsDto
                           {
                               CustomerId = c.CustomerId,
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               EMail = u.Email,
                               Password = u.PasswordHash,
                               CompanyName = c.CompanyName
                           };
                #endregion

                return (filter == null ? data.ToList() :
                                     data.Where(filter).ToList());
            }
        }

        public CustomerDetailsDto GetCustomerDetailsById(Expression<Func<CustomerDetailsDto, bool>> filter)
        {
            using (EfProjectContext context = new EfProjectContext())
            {
                #region Data
                var data = from c in context.Customers
                           join u in context.Users on c.UserId equals u.UserId
                           select new CustomerDetailsDto
                           {
                               CustomerId = c.CustomerId,
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               EMail = u.Email,
                               Password = u.PasswordHash,
                               CompanyName = c.CompanyName
                           };
                #endregion

                return data.FirstOrDefault(filter);
            }
        }
    }
}
