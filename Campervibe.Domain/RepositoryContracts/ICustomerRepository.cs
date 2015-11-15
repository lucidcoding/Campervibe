using Campervibe.Domain.Common;
using Campervibe.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Campervibe.Domain.RepositoryContracts
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        Customer GetByUsername(string username);
        IList<Customer> GetAllOrderedByFamilyName();
    }
}

