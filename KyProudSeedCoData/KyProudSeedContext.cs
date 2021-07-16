using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyProudSeedCoData
{
    public class KyProudSeedContext : DbContext
    {
        private readonly IConfiguration _config;

        public KyProudSeedContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Vegetable> Vegetables { get; set; }

        public DbSet<Variety> Varieties { get; set; }

        public DbSet<Packet> Packets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Vegetable>.Add(new { 
            
            
            })
        
        
        }
    }
}
