using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using Infrastructure.Context;

namespace Notes.Api
{
    public class AplicationContextFactory : IDesignTimeDbContextFactory<RaffleDbContext>
    {
        public RaffleDbContext CreateDbContext(string[] args)
        {
            var Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var optionsBuilder = new DbContextOptionsBuilder<RaffleDbContext>();
            optionsBuilder.UseSqlServer(Config.GetConnectionString("DefaultConnection"), sqlopts =>
            {
                sqlopts.MigrationsHistoryTable("_MigrationHistory", Config.GetValue<string>("SchemaName"));
            });

            return new RaffleDbContext(optionsBuilder.Options);
        }
    }
}