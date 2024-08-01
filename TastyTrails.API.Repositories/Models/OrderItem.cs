namespace TastyTrails.API.Repositories.Models
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public int MenuItemId { get; set; }
        public virtual MenuItem? MenuItem { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
