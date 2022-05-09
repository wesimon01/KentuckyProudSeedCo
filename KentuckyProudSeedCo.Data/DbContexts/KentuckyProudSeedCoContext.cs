using KentuckyProudSeedCo.Data.Entities;
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
        public DbSet<PlantProduct> PlantProducts { get; set; } = null!;
        public DbSet<SeedProduct> SeedProducts { get; set; } = null!;
        public DbSet<Fact> Facts { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<ProductGroup> ProductGroups { get; set; } = null!;
        
        public KentuckyProudSeedCoContext(DbContextOptions<KentuckyProudSeedCoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseSqlite("connectionString");
            base.OnConfiguring(optionsBuilder);           
        }

    }
}
