using Domain.Ports;
using Domain.Ports.Repository;
using Infrastructura.Adapters;
using Infrastructure.Adapters.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection ConnectionString(this IServiceCollection svc, IConfiguration config)
        {
            var i = config.GetConnectionString("DefaultConnection");
            svc.AddDbContext<RaffleDbContext>(options =>options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            svc.AddTransient<IServiceRepository, ServiceRepository>();
            svc.AddTransient<IRafflesRepository, RafflesRepository>();
            return svc;
        }
    }
}
