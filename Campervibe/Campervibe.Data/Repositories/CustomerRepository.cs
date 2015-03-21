using Campervibe.Data.Common;
using Campervibe.Domain.Entities;
using Campervibe.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campervibe.Data.Repositories
{
    public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public Customer GetByUsername(string username)
        {
            return Context
                .Customers
                .Where(customer => customer.User.Username.Equals(username))
                .Single();
        }

        public IList<Customer> GetAllOrderedByFamilyName()
        {
            return Context
                .Customers
                .OrderBy(customer => customer.FamilyName)
                .ToList();
        }
    }
}
