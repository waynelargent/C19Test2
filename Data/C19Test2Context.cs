using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C19Test2.Models;

namespace C19Test2.Data
{
    public class C19Test2Context : DbContext
    {
        public C19Test2Context (DbContextOptions<C19Test2Context> options)
            : base(options)
        {
        }

        public DbSet<C19Test2.Models.Case> Case { get; set; }

        public DbSet<C19Test2.Models.Department> Department { get; set; }

        public DbSet<C19Test2.Models.Location> Location { get; set; }

        public DbSet<C19Test2.Models.Status> Status { get; set; }
    }
}
