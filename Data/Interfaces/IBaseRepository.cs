using Response_Handler.Interfaces;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IResult> CreateAsync(TEntity entity);
    Task<IResultContent<IEnumerable<TEntity>>> GetAllAsync();
    Task<IResultContent<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IResult> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IResult> UpdateAsync(TEntity entity);
    Task<IResult> DeleteAsync(TEntity entity);
}
