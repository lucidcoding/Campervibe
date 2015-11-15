using Campervibe.Domain.Entities;

namespace Campervibe.Domain.Requests
{
    public class CheckOutForServicingRequest
    {
        public User CheckedOutBy { get; set; }
    }
}
