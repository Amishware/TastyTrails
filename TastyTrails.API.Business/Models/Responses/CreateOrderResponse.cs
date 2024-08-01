namespace TastyTrails.API.Business.Models.Responses
{
    public class CreateOrderResponse
    {
        public string? Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }
}
