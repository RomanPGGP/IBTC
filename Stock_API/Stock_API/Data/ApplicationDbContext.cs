using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock_API.Models;

namespace Stock_API.Data
{
    public class ApplicationDbContext: DbContext
    {

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockEntries> StockEntries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
