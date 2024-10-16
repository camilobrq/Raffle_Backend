using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Domain.Ports;
public interface IGenericRepository<E> 
       where E : IEntityBase<Guid>
{
    Task<E> GetByIdAsync(Guid id);
    Task<IEnumerable<E>> GetAllAsync();
    Task<E> GetByFilterAsync(E filter);
    Task<IEnumerable<E>> GetAllFilterAsync(E filter);
    Task<bool> AddAsync(E entity);
    Task<bool> UpdateAsync(E entity);
    Task<bool> DeleteAsync(Guid id);
    Task<List<E>> GetFilterAll(Expression<Func<E, bool>> filter);
    Task<E> GetFilter(Expression<Func<E, bool>> filter);
    Task<List<E>> GetQueryAll(string query);
    Task<E> GetQuery(string query);
}

