namespace TastyTrails.API.Business.Models.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public MenuDto Menu { get; set; }
        public int PaymentDetailsId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ImageUrl { get; set; }
    }
}
