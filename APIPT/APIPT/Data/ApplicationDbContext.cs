using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIPT.Models;

namespace APIPT.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Student> Studnts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
