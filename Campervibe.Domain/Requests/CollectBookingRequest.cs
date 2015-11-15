using Campervibe.Domain.Entities;

namespace Campervibe.Domain.Requests
{
    public class CollectBookingRequest
    {
        public int? Mileage { get; set; }
        public User LoggedBy { get; set; }
    }
}
