using Campervibe.Domain.Common;
using Campervibe.Domain.Entities;
using System;

namespace Campervibe.Domain.RepositoryContracts
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        Role GetByName(string roleName);
    }
}
