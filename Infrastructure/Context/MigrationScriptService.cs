using Domain.Entities.Base; 
using System.Reflection;

namespace Infrastructura.Context;

public static class MigrationScriptService
{
    public static IEnumerable<string> GenerateScripts()
    {
        var domainEntityTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(DomainEntity)));

        var scripts = new List<string>();

        foreach (var type in domainEntityTypes)
        {
            try
            {
                var createTableMethod = typeof(SqlScriptGenerator).GetMethod(nameof(SqlScriptGenerator.GenerateCreateTableScript)) ?? throw new InvalidOperationException("Method GenerateCreateTableScript not found.");
                var storedProceduresMethod = typeof(SqlScriptGenerator).GetMethod(nameof(SqlScriptGenerator.GenerateStoredProcedures)) ?? throw new InvalidOperationException("Method GenerateStoredProcedures not found.");

                //var createTableScript = (string)createTableMethod.MakeGenericMethod(type).Invoke(null, null);
                //var storedProceduresScript = (string)storedProceduresMethod.MakeGenericMethod(type).Invoke(null, null);

                //if (storedProceduresScript != null)
                //    scripts.Add(storedProceduresScript);
                //if (createTableScript != null)
                //    scripts.Add(createTableScript);
            }
            catch (Exception ex)
            {
                // Log or handle the error accordingly
                Console.WriteLine($"Error generating script for {type.Name}: {ex.Message}");
            }
        }

        return scripts;
    }

    
}