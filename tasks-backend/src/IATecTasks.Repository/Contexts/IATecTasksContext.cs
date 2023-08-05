using IATecTasks.Domain;
using IATecTasks.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Repository
{
    public class IATecTasksContext : IdentityDbContext<User, Role, string, 
                                                        IdentityUserClaim<string>, UserRole, 
                                                        IdentityUserLogin<string>, IdentityRoleClaim<string>, 
                                                        IdentityUserToken<string>>
    {
        public IATecTasksContext(DbContextOptions<IATecTasksContext> options) : base(options) { }

        public DbSet<ETask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRole)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(u => u.User)
                    .WithMany(ur => ur.UserRoles)
                    .HasForeignKey(r => r.UserId)
                    .IsRequired();
            });
        }
    }
}
