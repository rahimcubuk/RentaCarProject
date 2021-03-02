using Core.Entities.Concrete;
using Project.Business.Abstract.Repository;
using System.Collections.Generic;

namespace Project.Business.Abstract.Services
{
    public interface IUserService : IServiceRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
