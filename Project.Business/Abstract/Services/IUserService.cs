﻿using Project.Business.Abstract.Repository;
using Project.Entities.Concrete.Models;

namespace Project.Business.Abstract.Services
{
    public interface IUserService : IServiceRepository<User>
    {
    }
}
