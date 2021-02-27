using Project.Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Project.Entities.Concrete.DTOs;
using Project.Entities.Concrete.Models;
using System.Collections.Generic;

namespace Project.Business.Abstract.Services
{
    public interface ICustomerService : IServiceRepository<Customer>
    {
        IDataResult<CustomerDetailsDto> GetCustomerDetailById(int id);
        IDataResult<List<CustomerDetailsDto>> GetCustomersDetails();
    }
}
