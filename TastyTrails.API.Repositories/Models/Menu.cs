namespace TastyTrails.API.Repositories.Models
{
    public class Menu : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
