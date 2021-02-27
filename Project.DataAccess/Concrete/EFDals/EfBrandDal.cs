using Core.DataAccess.Repositories;
using Project.DataAccess.Abstract.Dals;
using Project.DataAccess.Concrete.Contexts;
using Project.Entities.Concrete.Models;

namespace Project.DataAccess.Concrete.EFDals
{
    public class EfBrandDal : EntityRepository<Brand, EfProjectContext>, IBrandDal
    {
    }
}
