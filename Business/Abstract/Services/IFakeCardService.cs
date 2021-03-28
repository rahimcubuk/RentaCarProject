using Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Models;

namespace Business.Abstract.Services
{
    public interface IFakeCardService : IServiceRepository<FakeCreditCard>
    {
        IDataResult<FakeCreditCard> CheckCard(FakeCreditCard card, decimal price);
    }
}
