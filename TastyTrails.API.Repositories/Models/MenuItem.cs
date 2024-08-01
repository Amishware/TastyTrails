namespace TastyTrails.API.Repositories.Models
{
    public class MenuItem : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int MenuId { get; set; }
        public virtual Menu? Menu { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public virtual ICollection<IngredientQuantity> IngredientQuantities { get; set; }
    }
}
