using Microsoft.AspNetCore.Authorization.Policy;

namespace TastyTrails.Common.Authorization
{
    public class PermissionEvaluator : IPermissionEvaluator
    {
        public async Task<PolicyAuthorizationResult> HandleAsync(IPermissionStore permissionStore, ICollection<IPermissionData> permissionData)
        {
            var permissionTasks = permissionData.Select(x => x.ResolveAsync(permissionStore));
            var permissionResult = await Task.WhenAll(permissionTasks);
            if (permissionResult.Any(x => !x))
            {
                return PolicyAuthorizationResult.Forbid();
            }

            return PolicyAuthorizationResult.Success();
        }
    }
}
