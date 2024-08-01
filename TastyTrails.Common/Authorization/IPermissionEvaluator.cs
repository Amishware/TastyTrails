using Microsoft.AspNetCore.Authorization.Policy;

namespace TastyTrails.Common.Authorization
{
    public interface IPermissionEvaluator
    {
        Task<PolicyAuthorizationResult> HandleAsync(IPermissionStore permissionStore, ICollection<IPermissionData> permissionData);
    }
}
