using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using Project.DataAccess.Abstract.Dals;
using Project.DataAccess.Concrete.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Project.DataAccess.Concrete.EFDals
{
    public class EfUserDal : EntityRepository<User, EfProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EfProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.ClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}