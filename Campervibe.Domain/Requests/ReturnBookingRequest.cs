using Campervibe.Domain.Entities;

namespace Campervibe.Domain.Requests
{
    public class ReturnBookingRequest
    {
        public int? Mileage { get; set; }
        public User LoggedBy { get; set; }
    }
}
