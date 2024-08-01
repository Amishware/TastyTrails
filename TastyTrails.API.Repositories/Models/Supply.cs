namespace TastyTrails.API.Repositories.Models
{
    public class Supply : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<SupplyItem> SupplyItems { get; set; }
    }
}
