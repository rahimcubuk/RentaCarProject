using Core.DataAccess.Repositories;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EFDals
{
    public class FakeCreditCardDal : EntityRepository<FakeCreditCard, EfProjectContext>, IFakeCreditCardDal
    {
        public FakeCreditCard GetCardByCardNumber(Expression<Func<FakeCreditCard, bool>> filter)
        {
            using(EfProjectContext context = new EfProjectContext())
            {
                return context.FakeCreditCards.SingleOrDefault(filter);
            }
        }
    }
}
