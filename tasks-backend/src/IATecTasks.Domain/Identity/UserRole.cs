﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Domain.Identity
{
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
