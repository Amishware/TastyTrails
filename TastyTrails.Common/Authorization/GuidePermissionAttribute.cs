using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TastyTrails.Common.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : Attribute, IPermissionData
    {
        public SystemPermissions[] Permissions { get; }

        public PermissionAttribute(params SystemPermissions[] permissions)
        {
            Permissions = permissions;
        }

        public async Task<bool> ResolveAsync(IPermissionStore permissionStore)
        {
            var permissions = await permissionStore.GetAsync();
            return permissions.Any(x => this.Permissions.Contains(x));
        }
    }
}
