namespace Coterie.Api.Models.Requests
{
    public class RatingRequest
    {
        public string Business { get; set; }
        public int Revenue { get; set; }
        public string[] States { get; set; }
    }
}
