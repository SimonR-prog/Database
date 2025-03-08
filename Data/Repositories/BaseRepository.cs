using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Response_Handler.Interfaces;
using Response_Handler.Models;
using System.Linq.Expressions;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _db = context.Set<TEntity>();

    public virtual async Task<IResult> CreateAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
            {
                return Result.Error("Entity is null.");
            }

            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Error($"An error occurred: {ex.Message}");
        }
    }

    //Can use predicate or expression.
    //The expression is a function which takes in an entity and returns a bool.
    public virtual async Task<IResult> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var exists = await _db.AnyAsync(predicate);

            // The part after ? is an if else and exists is the determining factor. Options = True : False.
            return exists ? Result.Ok() : Result.NotFound("Entity not found.");
        }
        catch (Exception ex)
        { 
            return Result.Error($"An error occurred: {ex.Message}");
        }
    }

    public virtual async Task<IResultContent<IEnumerable<TEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _db.ToListAsync();

            // In case the list is empty this will return an empty list of the entity type.
            if (entities.Count == 0)
                return Result<IEnumerable<TEntity>>.Ok(new List<TEntity>());

            return Result<IEnumerable<TEntity>>.Ok(entities);
        }
        catch (Exception ex) 
        {
            //Will return a new, empty list of entity on error.
            return Result<IEnumerable<TEntity>>.Error(new List<TEntity>(), $"An error occurred: {ex.Message}");
        }
    }
    
    public virtual async Task<IResultContent<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = await _db.FirstOrDefaultAsync(predicate);

            if (entity == null)
                return Result<TEntity>.Error(null, "Entity is null.");

            return Result<TEntity>.Ok(entity);
        }
        catch (Exception ex)
        {
            return Result<TEntity>.Error(null ,$"An error occurred: {ex.Message}");
        }
    }

    public virtual async Task<IResult> UpdateAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
                return Result.Error("Entity is null.");

            var result = await ExistsAsync(e => e == entity);
            if (result.Success == false)
                return Result.NotFound("Entity not found.");

            _db.Update(entity);
            await _context.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Error($"An error occurred: {ex.Message}");
        }
    }

    public virtual async Task<IResult> DeleteAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
                return Result.Error("Entity is null.");

            var result = await ExistsAsync(e => e == entity);
            if (result.Success == false)
                return Result.NotFound("Entity not found.");

            _db.Remove(entity);
            await _context.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Error($"An error occurred: {ex.Message}");
        }
    }
}
