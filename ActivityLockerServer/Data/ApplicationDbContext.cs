using System;
using System.Collections.Generic;
using System.Text;
using ActivityLockerServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActivityLockerServer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserActivityUser> UserActivityUsers { get; set; }
    }
}
