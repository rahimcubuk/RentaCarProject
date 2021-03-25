using Core.DataAccess.Repositories;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EFDals
{
    public class EfFakeCreditCardDal : EntityRepository<FakeCreditCard, EfProjectContext>, IFakeCreditCardDal
    {
    }
}
