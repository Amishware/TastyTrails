using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TastyTrails.API.Repositories.Models;
using TastyTrails.Common.Authorization;

namespace TastyTrails.API.Repositories
{
    public class TastyTrailsDbContext : IdentityUserContext<User, int, IdentityUserClaim<int>, IdentityUserLogin<int>, IdentityUserToken<int>>
    {
        public TastyTrailsDbContext(DbContextOptions<TastyTrailsDbContext> options)
            : base(options)
        { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }


        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supply> Supplys { get; set; }
        public DbSet<SupplyItem> SupplyItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var userEntity = modelBuilder.Entity<User>();
            userEntity.ToTable("User").HasKey(x => x.Id);
            userEntity.Property(i => i.Id).UseIdentityColumn(seed: 20000, increment: 1);

            modelBuilder.AddBaseEntityModel<Restaurant>();
            modelBuilder.AddBaseEntityModel<Supply>();
            modelBuilder.AddBaseEntityModel<SupplyItem>();
            modelBuilder.AddBaseEntityModel<Menu>();
            modelBuilder.AddBaseEntityModel<MenuItem>();
            modelBuilder.AddBaseEntityModel<Ingredient>();
            modelBuilder.AddBaseEntityModel<IngredientQuantity>();
            modelBuilder.AddBaseEntityModel<Customer>();
            modelBuilder.AddBaseEntityModel<SSKDevice>();
            modelBuilder.AddBaseEntityModel<Partner>();
            modelBuilder.AddBaseEntityModel<Order>();
            modelBuilder.AddBaseEntityModel<OrderItem>();

            SeedIngredient(modelBuilder.Entity<Ingredient>());
            SeedRestaurant(modelBuilder.Entity<Restaurant>());
            SeedSupply(modelBuilder.Entity<Supply>());
            SeedSupplyItems(modelBuilder.Entity<SupplyItem>());
            SeedMenu(modelBuilder.Entity<Menu>());
            SeedMenuItems(modelBuilder.Entity<MenuItem>());
            SeedIngredientQuantity(modelBuilder.Entity<IngredientQuantity>());
            SeedPermissions(modelBuilder.Entity<Permission>());
        }

        private void SeedIngredient(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasData(new Ingredient
            {
                Id = 1,
                Name = "Tomato",
            }, new Ingredient
            {
                Id = 2,
                Name = "Potato",
            });
        }

        private void SeedSupply(EntityTypeBuilder<Supply> builder)
        {
            builder.HasData(new Supply
            {
                Id = 1,
                Name = "Supply for restaurant 1"
            });
        }

        private void SeedSupplyItems(EntityTypeBuilder<SupplyItem> builder)
        {
            builder.HasData(
                new SupplyItem
                {
                    Id = 1,
                    SupplyId = 1,
                    IngredientId = 1,
                    Quantity = 10,
                },
                new SupplyItem
                {
                    Id = 2,
                    SupplyId = 1,
                    IngredientId = 2,
                    Quantity = 25,
                });
        }

        private void SeedMenu(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(new Menu
            {
                Id = 1,
                Name = "Menu for restaurant 1"
            });
        }

        private void SeedMenuItems(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasData(
                new MenuItem
                {
                    Id = 1,
                    MenuId = 1,
                    Name = "Salad",
                    Price = 2.33f,
                },
                new MenuItem
                {
                    Id = 2,
                    MenuId = 1,
                    Name = "Salad 2",
                    Price = 3.22f,
                });
        }

        private void SeedIngredientQuantity(EntityTypeBuilder<IngredientQuantity> builder)
        {
            builder.HasData(new IngredientQuantity
            {
                Id = 1,
                MenuItemId = 1,
                IngredientId = 1,
                Quantity = 1
            }, new IngredientQuantity
            {
                Id = 2,
                MenuItemId = 1,
                IngredientId = 2,
                Quantity = 2
            }, new IngredientQuantity
            {
                Id = 3,
                MenuItemId = 2,
                IngredientId = 1,
                Quantity = 2
            }, new IngredientQuantity
            {
                Id = 4,
                MenuItemId = 2,
                IngredientId = 2,
                Quantity = 2
            });
        }

        private void SeedRestaurant(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasData(new Restaurant
            {
                Id = 1,
                SupplyId = 1,
                MenuId = 1,
                Name = "Restaurant 1",
                Address = "Street 1"
            });
        }

        private void SeedPermissions(EntityTypeBuilder<Permission> builder)
        {
            foreach (var @enum in Enum.GetValues(typeof(SystemPermissions)))
            {
                var enumName = Enum.GetName(typeof(SystemPermissions), @enum);
                var permission = new Permission
                {
                    Id = (int)@enum,
                    Name = enumName
                };
                builder.HasData(permission);
            }
        }
    }
}
