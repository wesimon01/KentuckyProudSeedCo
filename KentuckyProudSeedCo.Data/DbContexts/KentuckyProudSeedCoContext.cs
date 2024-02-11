using KentuckyProudSeedCo.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KentuckyProudSeedCo.Data.DbContexts
{
    public class KentuckyProudSeedCoContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration config;

        public DbSet<PlantProduct> PlantProducts { get; set; } = null!;
        public DbSet<SeedProduct> SeedProducts { get; set; } = null!;
        public DbSet<Fact> Facts { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<ProductGroup> ProductGroups { get; set; } = null!;

        public KentuckyProudSeedCoContext(DbContextOptions<KentuckyProudSeedCoContext> options, IConfiguration config) : base(options)
        {
            this.config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseSqlServer(config.GetConnectionString("KyProudSeedCo"));
            base.OnConfiguring(optionsBuilder);           
        }

    }
}
