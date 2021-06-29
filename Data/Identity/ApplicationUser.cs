using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Twenty.Data.Domain;
using Microsoft.AspNetCore.Identity;

namespace Twenty.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        [Required]
        // [Range(DataConstants.MinUserAge, DataConstants.MaxUserAge)]
        public int Age { get; set; }

        public bool IsOnline { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
        
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}