using System.Reflection;

namespace Infrastructura;

public static class AppAssembly
{

    public static Assembly ApplicationAssembly { get; set; } = Assembly.Load(AppConstants.ApplicationProject);
    public static Assembly ApiAssembly { get; set; } = Assembly.Load(AppConstants.ApiProject);
    public static Assembly DomainAssembly { get; set; } = Assembly.Load(AppConstants.DomainProject);
}
