using Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Abstract.Services
{
    public interface ICustomerService : IServiceRepository<Customer>
    {
        IDataResult<CustomerDetailsDto> GetCustomerDetailById(int id);
        IDataResult<List<CustomerDetailsDto>> GetCustomersDetails();
    }
}
