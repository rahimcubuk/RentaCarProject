using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Project.Business.Abstract.Repository;
using System.Collections.Generic;

namespace Project.Business.Abstract.Services
{
    public interface IUserService : IServiceRepository<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
