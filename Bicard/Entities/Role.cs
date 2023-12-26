using Microsoft.AspNetCore.Identity;

namespace Bicard.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role() { } // Add a parameterless constructor

        public Role(string roleName) : base(roleName)
        {
            // Additional custom initialization logic if needed
        }

        // Add any additional properties or methods specific to your custom role
    }
}
