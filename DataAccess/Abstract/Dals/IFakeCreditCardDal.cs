using Core.DataAccess.Repositories;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Dals
{
    public interface IFakeCreditCardDal : IEntityRepository<FakeCreditCard>
    {
    }
}
