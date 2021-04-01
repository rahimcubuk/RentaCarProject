using Core.DataAccess.Repositories;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Dals
{
    public interface IUserCardDal : IEntityRepository<UserCard>
    {
        UserCardDetailsDto GetUserCardById(Expression<Func<UserCardDetailsDto, bool>> filter);
        List<UserCardDetailsDto> GetUserCardsByUserId(Expression<Func<UserCardDetailsDto, bool>> filter);
    }
}
