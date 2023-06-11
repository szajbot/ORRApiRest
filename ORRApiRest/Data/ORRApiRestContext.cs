using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ORRApiRest;

namespace ORRApiRest.Data
{
    public class ORRApiRestContext : DbContext
    {
        public ORRApiRestContext (DbContextOptions<ORRApiRestContext> options)
            : base(options)
        {
        }

        public DbSet<ORRApiRest.Car> Car { get; set; } = default!;
    }
}
