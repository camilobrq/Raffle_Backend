using Domain.Ports;
using Infrastructura;
using Infrastructure.Adapters.Jwt;
using Microsoft.Extensions.DependencyInjection;
using Notes.Domain.Services.Base;
using System.Reflection;

namespace Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        var _services = new List<Type>();

        Assembly assembly = Assembly.Load(AppConstants.DomainProject);

        _services.AddRange(assembly.GetTypes()
               .Where(p => p.CustomAttributes.Any(x => x.AttributeType 
               == typeof(DomainServiceAttribute))));
        services.AddTransient<IJwtServices, JwtService>();
        _services.ForEach(serviceType => services.AddTransient(serviceType));

        return services;
    }
}
