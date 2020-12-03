using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Models
{
    public class PhonesContext: DbContext
    {
        public PhonesContext(DbContextOptions<PhonesContext> options)
                : base(options)
        {
        }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

    }
}
