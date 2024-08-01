using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TastyTrails.API.Repositories
{
    public static class DbContextExtensions
    {
        public static ModelBuilder AddBaseEntityModel<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : class, IEntity
        {
            var entity = modelBuilder.Entity<TEntity>();

            entity.HasKey("Id");
            entity.Property(x => x.Id)
                .UseIdentityColumn();
            entity.Property(x => x.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .Metadata
                .SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(x => x.UpdatedOn)
               .ValueGeneratedOnAddOrUpdate()
               .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            return modelBuilder;
        }
    }
}
