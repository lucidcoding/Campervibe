//using Campervibe.Domain.Common;
//using Campervibe.Domain.Enumerations;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Campervibe.Domain.Entities
//{
//    public class Vehicle : Entity<Guid>
//    {
//        public virtual string Name { get; set; }
//        public virtual string RegistrationNumber { get; set; }
//        public virtual string Make { get; set; }
//        public virtual string Model { get; set; }
//        public virtual decimal PricePerDay { get; set; }
//        public virtual Depot HomeDepot { get; set; }
//        public virtual ICollection<Booking> Bookings { get; set; }

//        public virtual VehicleStatus Status { get; set; }

//        public decimal? Mileage
//        {
//            get
//            {
//                return Bookings.Any() ? Bookings.Max(booking => booking.EndMileage) : null;
//            }
//        }

//        public virtual IList<Booking> GetConflictingBookings(DateTime startDate, DateTime endDate)
//        {
//            return Bookings.Where(booking =>
//                (startDate >= booking.StartDate && startDate < booking.EndDate)
//                || (endDate > booking.StartDate && endDate <= booking.EndDate)
//                || (startDate <= booking.StartDate && endDate >= booking.EndDate))
//                .ToList();
//        }
//    }
//}
