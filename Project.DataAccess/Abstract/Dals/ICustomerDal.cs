using Project.Core.DataAccess.Repositories;
using Project.Entities.Concrete.DTOs;
using Project.Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Abstract.Dals
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetailsDto> GetAllCustomerDetails(Expression<Func<CustomerDetailsDto, bool>> filter = null);
        CustomerDetailsDto GetCustomerDetailsById(Expression<Func<CustomerDetailsDto, bool>> filter);
    }
}
