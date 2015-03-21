using Campervibe.Domain.Entities;
using System;

namespace Campervibe.Domain.Requests
{
    public class MakeBookingRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
