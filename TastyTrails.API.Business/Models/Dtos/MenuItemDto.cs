namespace TastyTrails.API.Business.Models.Dtos
{
    public class MenuItemDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
