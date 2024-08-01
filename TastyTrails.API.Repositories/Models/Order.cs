namespace TastyTrails.API.Repositories.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int RestaurantId { get; set; }
        public int? CustomerId { get; set; }
        public int? SSKDeviceId { get; set; }
        public int? PartnerId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string? TransactionId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
