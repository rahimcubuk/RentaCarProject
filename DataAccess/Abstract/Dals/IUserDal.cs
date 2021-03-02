using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract.Dals
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        void AddUserClaim(UserOperationClaim entity);
    }
}