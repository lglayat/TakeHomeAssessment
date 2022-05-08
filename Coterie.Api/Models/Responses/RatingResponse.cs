using System;

namespace Coterie.Api.Models.Responses
{
    public class RatingResponse
    {
        public string Business { get; set; }
        public decimal Revenue { get; set; }
        public PremiumWrapper[] Premiums { get; set; }
        public bool IsSuccessful { get; } = true;
        public string TransactionId { get; } = Guid.NewGuid().ToString();
    }

    public class PremiumWrapper
    {
        public decimal Premium { get; set; }
        public string State { get; set; }
    }
}
