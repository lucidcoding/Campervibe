using Campervibe.Domain.Common;
using Campervibe.Domain.Entities;
using System;

namespace Campervibe.Domain.RepositoryContracts
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        User GetByUsername(string userName);
    }
}

