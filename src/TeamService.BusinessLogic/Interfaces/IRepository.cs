namespace TeamService.BusinessLogic.Interfaces;

/// <summary>
/// Provides methods that should be implemented in the repository.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Gets the entity by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Entity with a specific id.</returns>
    public Task<T> GetById(Guid id);

    /// <summary>
    /// Creates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task of writing an object to the database.</returns>
    public Task Create(T entity);

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task of updating an object in the database.</returns>
    public Task Update(T entity);

    /// <summary>
    /// Deletes the entity with specified identifier.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <returns>Task of deleting an object in the database</returns>
    public Task Delete(Guid entityId);

    /// <summary>
    /// Gets the range of entities.
    /// </summary>
    /// <param name="startPoint">The start point.</param>
    /// <param name="count">The count.</param>
    /// <returns>A range of entities of size <paramref name="count"/> starting from <paramref name="startPoint"/>.</returns>
    public Task<IEnumerable<T>> GetRange(int startPoint, int count);
}
