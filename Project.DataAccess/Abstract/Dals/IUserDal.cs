using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Project.DataAccess.Abstract.Dals
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}