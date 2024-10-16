using Domain.Entities.Raffle;
using Domain.Entities.Raflee;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Context
{
    public class RaffleDbContext : DbContext
    {
        public RaffleDbContext(DbContextOptions<RaffleDbContext> dbContext) : base(dbContext)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 4);

            base.ConfigureConventions(configurationBuilder);
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Raffle> Raffles { get; set; }

    }
}
