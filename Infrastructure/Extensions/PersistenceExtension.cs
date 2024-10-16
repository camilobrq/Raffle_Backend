using Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Data;
using Infrastructura.Adapters;

namespace Authentication.Infrastrunture.Extensions;

public static class PersistenceExtension
{
    public static IServiceCollection AddPesistence(this IServiceCollection svc, IConfiguration config)
    {
        var i = config.GetConnectionString("DefaultConnection");
        svc.AddTransient<IDbConnection>((sp) => new SqlConnection(config.GetConnectionString("DefaultConnection")));
        svc.AddTransient(typeof(IGenericRepository<>), typeof(ServiceRepository<>));
        svc.AddScoped<IUnitOfWork, UnitOfWork>();
        return svc;
    }
}
