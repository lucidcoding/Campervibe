using Campervibe.Data.Common;
using Campervibe.Domain.Entities;
using Campervibe.Domain.RepositoryContracts;
using System;
using System.Linq;

namespace Campervibe.Data.Repositories
{
    public class RoleRepository : Repository<Role, Guid>, IRoleRepository
    {
        public RoleRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public Role GetByName(string roleName)
        {
            return Context
                .Roles
                .SingleOrDefault(role => role.RoleName == roleName);
        }
    }
}
