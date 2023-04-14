using Microsoft.AspNetCore.Identity;

namespace ProjektDziennik.Models
{
    public class Role : IdentityRole
    {
        public Role(string Name) : base(Name) { }
    }
}
