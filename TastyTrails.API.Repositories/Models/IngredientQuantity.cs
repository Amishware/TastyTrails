namespace TastyTrails.API.Repositories.Models
{
    public class IngredientQuantity : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public double Quantity { get; set; }
    }
}
