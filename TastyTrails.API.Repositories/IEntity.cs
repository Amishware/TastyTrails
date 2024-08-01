using System;

namespace TastyTrails.API.Repositories
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTimeOffset CreatedOn { get; set; }

        DateTimeOffset UpdatedOn { get; set; }
    }
}
