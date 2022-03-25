using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIFE.Models;

namespace APIFE.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Participant> participants { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
    }
}
