namespace TastyTrails.Common.Authorization
{
    public interface IPermissionData
    {
        SystemPermissions[] Permissions { get; }

        Task<bool> ResolveAsync(IPermissionStore permissionStore);
    }
}
