using System.Collections.Generic;
using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.UnitTests
{
    public static class Helper
    {
        public static Restaurant CreateRestaurantAndOffer()
        {
            return new Restaurant()
            {
                Id = 1,
                SupplyId = 1,
                MenuId = 1,
                Name = "Restaurant 1",
                Address = "Street 1",
                Email = "mail@restaurant.com",
                Supply = new Supply
                {
                    SupplyItems = new List<SupplyItem>
                    {
                        new SupplyItem
                        {
                            Id = 1,
                            IngredientId = 1,
                            Quantity = 10,
                        },
                        new SupplyItem
                        {
                            IngredientId = 2,
                            Quantity = 25,
                        }
                    }
                },
                Menu = new Menu
                {
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Id = 1,
                            Name = "Salad",
                            Price = 2,
                            IngredientQuantities = new List<IngredientQuantity>
                            {
                                new IngredientQuantity
                                {
                                    IngredientId = 1,
                                    Quantity = 1
                                }, new IngredientQuantity
                                {
                                    IngredientId = 2,
                                    Quantity = 2
                                }
                            }
                        },
                        new MenuItem
                        {
                            Id = 2,
                            Name = "Salad 2",
                            Price = 3,
                            IngredientQuantities = new List<IngredientQuantity>
                            {
                                new IngredientQuantity
                                {
                                    IngredientId = 1,
                                    Quantity = 2
                                }, new IngredientQuantity
                                {
                                    IngredientId = 2,
                                    Quantity = 2
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
