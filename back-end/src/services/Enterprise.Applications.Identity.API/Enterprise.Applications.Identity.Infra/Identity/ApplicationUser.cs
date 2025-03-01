using Microsoft.AspNetCore.Identity;

namespace Enterprise.Applications.Identity.Infra.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
