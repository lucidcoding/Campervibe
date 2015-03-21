using Campervibe.Domain.Common;
using Campervibe.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Campervibe.Domain.RepositoryContracts
{
    public interface IBookingRepository : IRepository<Booking, Guid>
    {
        IList<Booking> GetPendingForVehicle(Guid vehicleId);
        Booking GetByBookingNumber(string bookingNumber);
    }
}
