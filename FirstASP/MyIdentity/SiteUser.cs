using Microsoft.AspNetCore.Identity;
namespace FirstASP.MyIdentity
{
    public class SiteUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
