using Campervibe.Data.Common;
using Campervibe.Domain.Entities;
using Campervibe.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campervibe.Data.Repositories
{
    public class BookingRepository : Repository<Booking, Guid>, IBookingRepository
    {
        public BookingRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public IList<Booking> GetPendingForVehicle(Guid vehicleId)
        {
            return Context
                .Bookings
                .Where(booking => booking.StartDate >= DateTime.Now && booking.Vehicle.Id == vehicleId)
                .OrderByDescending(booking => booking.StartDate)
                .ToList();
        }

        public Booking GetByBookingNumber(string bookingNumber)
        {
            return Context
                .Bookings
                .Where(booking => booking.BookingNumber == bookingNumber)
                .SingleOrDefault();
        }
    }
}
