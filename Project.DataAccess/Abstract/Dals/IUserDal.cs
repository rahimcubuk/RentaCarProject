﻿using Project.Core.DataAccess.Repositories;
using Project.Entities.Concrete.Models;
namespace Project.DataAccess.Abstract.Dals
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}