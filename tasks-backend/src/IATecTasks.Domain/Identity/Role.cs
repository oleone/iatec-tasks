using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Domain.Identity
{
    public class Role : IdentityRole<string>
    {
        public IEnumerable<UserRole> UserRole { get; set; }
    }
}
