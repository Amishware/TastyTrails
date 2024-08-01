using System.Security.Claims;
using TastyTrails.Common.Extensions;
using TastyTrails.Common.Interfaces;

namespace TastyTrails.Common.Authorization
{
    public class DefaultUserMetaReader : IUserMetaReader
    {
        private readonly ClaimsPrincipal _claimsPrincipal;

        public DefaultUserMetaReader(
            ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }

        public int GetId()
        {
            return _claimsPrincipal.GetClaimValue<int>(ClaimTypes.NameIdentifier);
        }

        public string GetEmail()
        {
            return _claimsPrincipal.GetClaimValue<string>(ClaimTypes.Email);
        }

        public string GetUserName()
        {
            return _claimsPrincipal.GetClaimValue<string>(ClaimTypes.Name);
        }

        public string GetFullName()
        {
            return _claimsPrincipal.GetClaimValue<string>(CustomClaimTypes.FullName);
        }
    }
}
