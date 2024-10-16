using Authentication.Infrastrunture.Extensions;
using Infrastructure.Context;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure;

public static class Startup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddPesistence(config);
        services.AddDomainServices();
        services.AddJwtSettings(config);
        services.AddMediator();
        services.AddMapper();
        services.AddValidator();
        services.AddSwagger();
        services.AddCorsPolicy();
        services.AddControllers();
        services.ConnectionString(config);
    }

    public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCorsPolicy();
        app.UseSwaggers(env);
        app.UseExceptionMiddleware();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseHttpsRedirection();
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        InitializeDatabase(scope);
    }
    private static void InitializeDatabase(IServiceScope scope)
    {
        if (scope == null) return;
        MigrateDbContextExtensions.MigrateDbContextServices<RaffleDbContext>(scope);
        var context = scope.ServiceProvider.GetRequiredService<RaffleDbContext>();
        if (!context.Database.CanConnect()) return;
    }
}
