using Microsoft.AspNetCore.Identity;

namespace TastyTrails.API.Repositories.Models
{
    public class User : IdentityUser<int>
    {
        public ICollection<UserPermission> Permissions { get; set; }
    }
}
