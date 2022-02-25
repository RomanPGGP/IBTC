using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rum8s.Models;

namespace Rum8s.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<GroupR8> groups { get; set; }

        public DbSet<TasksR8> tasks { get; set; }
        public DbSet<UserGroupR8> userGroupR8s { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
