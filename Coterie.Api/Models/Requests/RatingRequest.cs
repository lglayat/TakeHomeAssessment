namespace Coterie.Api.Models.Requests
{
    public class RatingRequest
    {
        public string Business { get; set; }
        public decimal Revenue { get; set; }
        public string[] States { get; set; }
    }
}
