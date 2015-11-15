using Campervibe.Domain.Entities;

namespace Campervibe.Domain.Requests
{
    public class CheckInForServicingRequest
    {
        public Vehicle Vehicle { get; set; }
        public decimal? Mileage { get; set; }
        public User CheckedInBy { get; set; }
    }
}
