using Campervibe.Domain.Entities;
using Campervibe.Domain.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Campervibe.Domain.UnitTests.Entities.BookingTests
{
    [TestClass]
    public class MakeTests
    {
        [TestMethod]
        public void CanMakeBooking()
        {
            var request = new MakeBookingRequest();

            var customer = new Customer() { 
                Id = Guid.NewGuid(),
                FamilyName = "Blue"
            };

            request.Customer = customer;
            request.StartDate = new DateTime(2050, 10, 1);
            request.EndDate = new DateTime(2050, 10, 3);
            request.VehicleId = Guid.NewGuid();

            var booking = Booking.Make(request);

            Assert.IsNotNull(booking.Id);
            Assert.AreNotEqual(default(Guid), booking.Id.Value);
            Assert.IsNotNull(booking.BookingNumber);
            Assert.AreEqual(request.StartDate, booking.StartDate);
            Assert.AreEqual(request.EndDate, booking.EndDate);
            Assert.AreSame(customer, booking.Customer);
            Assert.AreSame(request.VehicleId.Value, booking.VehicleId);
            Assert.AreEqual(300m, booking.Total);
        }
    }
}
