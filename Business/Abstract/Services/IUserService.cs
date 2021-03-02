using Business.Abstract.Repository;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract.Services
{
    public interface IUserService : IServiceRepository<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IResult AddUserClaim(UserOperationClaim userOperationClaim);
    }
}
