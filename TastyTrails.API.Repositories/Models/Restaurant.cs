namespace TastyTrails.API.Repositories.Models
{
    public class Restaurant : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int SupplyId { get; set; }
        public Supply Supply { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int PaymentDetailsId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ImageUrl { get; set; }
    }
}
