using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentuckyProudSeedCo.Data.DbContexts
{
    public class KentuckyProudSeedCoContext : DbContext
    {
        public DbSet<string> MyProperty { get; set; } = null!;
        
        public KentuckyProudSeedCoContext(DbContextOptions<KentuckyProudSeedCoContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseSqlite("connectionString");
            base.OnConfiguring(optionsBuilder);           
        }

    }
}
