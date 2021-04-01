using Business.Abstract.Repository;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Abstract.Services
{
    public interface IUserCardService : IServiceRepository<UserCard>
    {
        IDataResult<UserCardDetailsDto> GetUserCardById(int id);
        IDataResult<List<UserCardDetailsDto>> GetUserCardByUserId(int userId);
    }
}
