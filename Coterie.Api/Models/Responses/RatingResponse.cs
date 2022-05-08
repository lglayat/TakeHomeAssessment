using System;

namespace Coterie.Api.Models.Responses
{
    public class RatingResponse
    {
        public string Business { get; set; }
        public int Revenue { get; set; }
        public PremiumWrapper[] Premiums { get; set; }
        public bool IsSuccessful { get; set; }
        public Guid TransactionId { get; set; }
    }

    public class PremiumWrapper
    {
        public int Premium { get; set; }
        public string State { get; set; }
    }
}
