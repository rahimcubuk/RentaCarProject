using Core.DataAccess.Repositories;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.Models;

namespace DataAccess.Concrete.EFDals
{
    public class EfFindexPointDal : EntityRepository<UserFindexPoint, EfProjectContext>, IFindexPointDal
    {
    }
}
