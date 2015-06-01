using Campervibe.Domain.Entities;
using System;

namespace Campervibe.Domain.Requests
{
    public class CheckInForServicingRequest
    {
        public Guid VehicleId { get; set; }
        public decimal? Mileage { get; set; }
        public User CheckedInBy { get; set; }
    }
}
