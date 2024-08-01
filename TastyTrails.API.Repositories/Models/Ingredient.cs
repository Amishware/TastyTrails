namespace TastyTrails.API.Repositories.Models
{
    public class Ingredient : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
