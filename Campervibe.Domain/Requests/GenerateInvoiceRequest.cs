using Campervibe.Domain.Entities;
using System;

namespace Campervibe.Domain.Requests
{
    public class GenerateInvoiceRequest
    {
        public string InvoiceNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public User GeneratedBy { get; set; }
    }
}
