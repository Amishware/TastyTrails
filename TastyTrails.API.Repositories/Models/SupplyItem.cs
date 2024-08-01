namespace TastyTrails.API.Repositories.Models
{
    public class SupplyItem : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int SupplyId { get; set; }
        public virtual Supply? Supply { get; set; }
        public int IngredientId { get; set; }
        public virtual Ingredient? Ingredient { get; set; }
        public double Quantity { get; set; }
    }
}
