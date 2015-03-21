using Campervibe.Data.Common;
using Campervibe.Domain.Entities;
using Campervibe.Domain.RepositoryContracts;
using System;
using System.Linq;

namespace Campervibe.Data.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public User GetByUsername(string username)
        {
            return Context
                .Users
                .SingleOrDefault(user => user.Username == username);
        }
    }
}
