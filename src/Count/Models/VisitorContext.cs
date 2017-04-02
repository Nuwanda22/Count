using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Count.Models
{
    public class VisitorContext : DbContext
    {
        public DbSet<VisitorItem> Visitors { get; set; }

        public VisitorContext(DbContextOptions<VisitorContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=visitor.db");
        //}
    }
}
