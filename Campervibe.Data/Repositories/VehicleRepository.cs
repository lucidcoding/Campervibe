using Campervibe.Data.Common;
using Campervibe.Domain.Entities;
using Campervibe.Domain.RepositoryContracts;
using System;

namespace Campervibe.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle, Guid>, IVehicleRepository
    {
        public VehicleRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }
    }
}
