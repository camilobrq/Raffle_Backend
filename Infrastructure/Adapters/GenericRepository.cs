using Domain.Entities.Base;
using Domain.Ports;
using Dapper;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructura.Adapters;

public class ServiceRepository<E>(IDbConnection dbConnection, IDbTransaction dbTransaction) 
    : IGenericRepository<E> where E : class, IEntityBase<Guid>
{
    private readonly IDbConnection _dbConnection = dbConnection;
    private readonly IDbTransaction _dbTransaction = dbTransaction;

    public async Task<E> GetByIdAsync(Guid id)
    {
        var spName = $"Select_{typeof(E).Name}";
        return (await _dbConnection.QueryFirstOrDefaultAsync<E>(spName, new { Id = id }, 
            _dbTransaction, commandType: CommandType.StoredProcedure))!;
    }

    public async Task<E> GetByFilterAsync(E filter)
    {
        var spName = $"Select_{typeof(E).Name}";
        var parameters = GetParameters(filter);
        var result = (await _dbConnection.QueryFirstOrDefaultAsync<E>(spName, parameters,
            _dbTransaction, commandType: CommandType.StoredProcedure))!;
        return result;
    }

    public async Task<IEnumerable<E>> GetAllAsync()
    {
        var spName = $"Select_{typeof(E).Name}";
        return await _dbConnection.QueryAsync<E>(spName, null, 
            _dbTransaction, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<E>> GetAllFilterAsync(E filter)
    {
        var spName = $"Select_{typeof(E).Name}";
        var parameters = GetParameters(filter);
        var result = await _dbConnection.QueryAsync<E>(spName, parameters,
            _dbTransaction, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<bool> AddAsync(E entity)
    {
        var spName = $"Add_{typeof(E).Name}";
        var parameters = GetParameters(entity);
        var result = await _dbConnection.ExecuteAsync(spName, parameters, 
            _dbTransaction, commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<bool> UpdateAsync(E entity)
    {
        var spName = $"Update_{typeof(E).Name}";
        var parameters = GetParameters(entity);
        var result = await _dbConnection.ExecuteAsync(spName, parameters, 
            _dbTransaction, commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var spName = $"Delete_{typeof(E).Name}";
        var result = await _dbConnection.ExecuteAsync(spName, new { Id = id }, _dbTransaction, commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<List<E>> GetFilterAll(Expression<Func<E, bool>> filter)
    {
        var query = ServiceRepository<E>.GetSqlQueryFromExpression(filter);
        return (await _dbConnection.QueryAsync<E>(query, transaction: 
            _dbTransaction)).ToList();
    }

    public async Task<E> GetFilter(Expression<Func<E, bool>> filter)
    {
        var query = ServiceRepository<E>.GetSqlQueryFromExpression(filter);
        return (await _dbConnection.QueryFirstOrDefaultAsync<E>(query, 
            transaction: _dbTransaction))!;
    }

    public async Task<List<E>> GetQueryAll(string query)
    {
        return (await _dbConnection.QueryAsync<E>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<E> GetQuery(string query)
    {
        return (await _dbConnection.QueryFirstOrDefaultAsync<E>(query, transaction: _dbTransaction))!;
    }

    private static DynamicParameters GetParameters(E entity)
    {
        var parameters = new DynamicParameters();
        foreach (var property in typeof(E).GetProperties())
        {
            if (IsSupportedSqlType(property.PropertyType))
            {
                var value = property.GetValue(entity);
                if (value != null && (!IsDefaultValue(value) 
                    || value.GetType() == typeof(bool)))
                {
                    parameters.Add($"@{property.Name}", value);
                }
            }
        }
        return parameters;
    }

    private static string GetSqlQueryFromExpression(Expression<Func<E, bool>> filter)
    {
        var queryBody = filter.Body.ToString();
        var paramName = filter.Parameters[0].Name;
        var query = new StringBuilder(queryBody);
        query.Replace(paramName + ".", string.Empty);
        query.Replace("AndAlso", "AND");
        query.Replace("OrElse", "OR");
        return $"SELECT * FROM {typeof(E).Name} WHERE {query}";
    }
    private static bool IsSupportedSqlType(Type type) =>
     type.IsPrimitive || type.IsEnum || type == typeof(string) ||
     type == typeof(decimal) || type == typeof(DateTime) ||
     type == typeof(Guid) || type == typeof(TimeSpan) ||
     type == typeof(byte[]);

    private static bool IsDefaultValue(object value) =>
        value == null || 
        (value is string str && string.IsNullOrEmpty(str)) ||
        (value.GetType().IsValueType &&
        value.Equals(Activator.CreateInstance(value.GetType())));

}
