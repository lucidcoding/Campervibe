using Campervibe.Data.Common;
using Campervibe.Domain.Entities;
using Campervibe.Domain.RepositoryContracts;
using System;

namespace Campervibe.Data.Repositories
{
    public class DepotRepository : Repository<Depot, Guid>, IDepotRepository
    {
        public DepotRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }
    }
}
