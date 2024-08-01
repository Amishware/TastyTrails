namespace TastyTrails.Common.Authorization
{
    public interface IPermissionStore
    {
        Task<IEnumerable<SystemPermissions>> GetAsync();
    }
}
