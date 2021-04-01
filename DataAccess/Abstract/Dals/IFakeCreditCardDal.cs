using Core.DataAccess.Repositories;
using Entities.Concrete.Models;

namespace DataAccess.Abstract.Dals
{
    public interface IFakeCreditCardDal : IEntityRepository<FakeCreditCard>
    {
    }
}
