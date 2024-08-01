namespace TastyTrails.Common.Authorization
{
    public enum SystemPermissions : int
    {
        RestaurantRead = 1,
        RestaurantWrite = 2,
        SupplyRead = 3,
        SupplyWrite = 4,
        MenuRead = 5,
        MenuWrite = 6,
        OrderRead = 7,
        OrderWrite = 8,
        IngredientRead = 9,
        IngredientWrite = 10,
        UserPermissionWrite = 11
    }
}
