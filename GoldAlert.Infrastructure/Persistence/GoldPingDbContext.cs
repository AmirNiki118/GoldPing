
using Microsoft.EntityFrameworkCore;
using GoldAlert.Domain.Users;
using GoldAlert.Domain.Alerts;
namespace GoldAlert.Infrastructure.Persistence
{
    public class GoldPingDbContext : DbContext
    {
        public GoldPingDbContext(DbContextOptions<GoldPingDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<PriceAlert> PriceAlerts => Set<PriceAlert>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoldPingDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
    