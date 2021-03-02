using Core.DataAccess.Repositories;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Dals
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetailsDto> GetAllCustomerDetails(Expression<Func<CustomerDetailsDto, bool>> filter = null);
        CustomerDetailsDto GetCustomerDetailsById(Expression<Func<CustomerDetailsDto, bool>> filter);
    }
}
