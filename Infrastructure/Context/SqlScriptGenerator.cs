using Domain.Entities.Base;
using System.Reflection;
using System.Text;


namespace Infrastructura.Context;

public static class SqlScriptGenerator
{
    private static readonly HashSet<Type> PrimitiveTypes =
    [
        typeof(int), typeof(long), typeof(decimal), typeof(double), typeof(float),
        typeof(bool), typeof(string), typeof(Guid), typeof(DateTime)
    ];

    public static string GenerateCreateTableScript<T>() where T : DomainEntity
    {
        var type = typeof(T);
        var tableName = type.Name + "s"; // Pluralize table name
        //var properties = GetPrimitiveProperties(type);

        var sb = new StringBuilder();
        sb.AppendLine($"CREATE TABLE {tableName} (");

        //foreach (var property in properties)
        //{
        //    var columnName = property.Name;
        //    var columnType = GetSqlType(property.PropertyType);
        //    sb.AppendLine($"    {columnName} {columnType},");
        //}

        // Remove the last comma and new line
        if (sb.Length > 0)
        {
            sb.Length -= 3; // Remove last ",\n"
        }
        sb.AppendLine();
        sb.AppendLine(");");

        return sb.ToString();
    }

    public static string GenerateStoredProcedures<T>() where T : DomainEntity
    {
        var type = typeof(T);
        var tableName = type.Name + "s";
        //var properties = GetPrimitiveProperties(type)
        //    .Select(p => p.Name);

        var sb = new StringBuilder();

        // Add Procedure
        sb.AppendLine($"CREATE PROCEDURE Add_{type.Name}");
        //sb.AppendLine(string.Join(",\n", properties.Select(p => $"    @{p} {GetSqlType(type.GetProperty(p).PropertyType)}")));
        sb.AppendLine("AS");
        sb.AppendLine("BEGIN");
        //sb.AppendLine($"    INSERT INTO {tableName} ({string.Join(", ", properties)})");
        //sb.AppendLine($"    VALUES ({string.Join(", ", properties.Select(p => $"@{p}"))});");
        sb.AppendLine("END;");
        sb.AppendLine();

        // Update Procedure
        sb.AppendLine($"CREATE PROCEDURE Update_{type.Name}");
        //sb.AppendLine(string.Join(",\n", properties.Select(p => $"    @{p} {GetSqlType(type.GetProperty(p).PropertyType)}")));
        sb.AppendLine("AS");
        sb.AppendLine("BEGIN");
        sb.AppendLine($"    UPDATE {tableName}");
        //sb.AppendLine($"    SET {string.Join(", ", properties.Select(p => $"{p} = @{p}"))}");
        sb.AppendLine($"    WHERE Id = @Id;");
        sb.AppendLine("END;");
        sb.AppendLine();

        // Delete Procedure
        sb.AppendLine($"CREATE PROCEDURE Delete_{type.Name}");
        sb.AppendLine("    @Id UNIQUEIDENTIFIER");
        sb.AppendLine("AS");
        sb.AppendLine("BEGIN");
        sb.AppendLine($"    DELETE FROM {tableName}");
        sb.AppendLine($"    WHERE Id = @Id;");
        sb.AppendLine("END;");
        sb.AppendLine();

        // Select Procedure
        sb.AppendLine($"CREATE PROCEDURE Select_{type.Name}s");
        sb.AppendLine("AS");
        sb.AppendLine("BEGIN");
        sb.AppendLine($"    SELECT * FROM {tableName};");
        sb.AppendLine("END;");
        sb.AppendLine();

        return sb.ToString();
    }

    //private static IEnumerable<PropertyInfo> GetPrimitiveProperties(Type type)
    //{
    //    return 
    //        type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
    //        .Where(p => IsPrimitiveType(p.PropertyType) ||
    //                    (Nullable.GetUnderlyingType(p.PropertyType) != null 
    //                    && IsPrimitiveType(Nullable.GetUnderlyingType(p.PropertyType))));
    //}

    private static bool IsPrimitiveType(Type type)
    {
        return PrimitiveTypes.Contains(type);
    }

    private static string GetSqlType(Type type)
    {
        type = Nullable.GetUnderlyingType(type) ?? type;

        if (type == typeof(int)) return "INT";
        if (type == typeof(long)) return "BIGINT";
        if (type == typeof(decimal)) return "DECIMAL(18,2)";
        if (type == typeof(double)) return "FLOAT";
        if (type == typeof(float)) return "REAL";
        if (type == typeof(bool)) return "BIT";
        if (type == typeof(string)) return "NVARCHAR(MAX)";
        if (type == typeof(Guid)) return "UNIQUEIDENTIFIER";
        if (type == typeof(DateTime)) return "DATETIME2";

        throw new NotSupportedException($"Type '{type.Name}' is not supported.");
    }
}
