using Campervibe.Domain.Entities;
using System;

namespace Campervibe.Domain.Requests
{
    public class MakeBookingRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? VehicleId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
