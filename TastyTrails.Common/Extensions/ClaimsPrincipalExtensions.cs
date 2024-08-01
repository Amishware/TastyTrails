using System.Security.Claims;

namespace TastyTrails.Common.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static object GetClaimValue(this ClaimsPrincipal principal, string type)
        {
            var claim = principal.Claims.FirstOrDefault(x => x.Type == type);
            if (claim is null)
            {
                return null;
            }

            var strVal = claim?.Value;
            if (string.IsNullOrEmpty(strVal))
            {
                return null;
            }

            return claim.ValueType switch
            {
                ClaimValueTypes.Integer or ClaimValueTypes.Integer32 => Convert.ToInt32(strVal),
                ClaimValueTypes.Integer64 => Convert.ToInt64(strVal),
                ClaimValueTypes.UInteger32 => Convert.ToUInt32(strVal),
                ClaimValueTypes.UInteger64 => Convert.ToUInt64(strVal),
                ClaimValueTypes.Date or ClaimValueTypes.Time or ClaimValueTypes.DateTime => DateTime.Parse(strVal),
                ClaimValueTypes.Boolean => Convert.ToBoolean(strVal),
                ClaimValueTypes.Double => Convert.ToDouble(strVal),
                _ => strVal,
            };
        }

        public static T GetClaimValue<T>(this ClaimsPrincipal principal, string type, T @default)
        {
            var value = principal.GetClaimValue(type);
            var nullableType = Nullable.GetUnderlyingType(typeof(T));
            var requestedType = nullableType ?? typeof(T);
            return value is null ? @default : (T)Convert.ChangeType(value, requestedType);
        }

        public static T GetClaimValue<T>(this ClaimsPrincipal principal, string type)
        {
            return principal.GetClaimValue<T>(type, default);
        }
    }
}
