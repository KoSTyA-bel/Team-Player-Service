namespace TeamService.BusinessLogic.Interfaces;

/// <summary>
/// Provides methods that should be implemented in the service.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public interface IService<T> where T : class
{
    /// <summary>
    /// Tries the get entity by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="entity">The entity.</param>
    /// <returns>True if database contains entity with specific id, false in other cases.</returns>
    public bool TryGetById(Guid id, out T entity);

    /// <summary>
    /// Creates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Entity.</returns>
    public Task<T> Create(T entity);

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Entity.</returns>
    public Task<T> Update(T entity);

    /// <summary>
    /// Deletes the entity with specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>True if the deletion was successful, false in other cases.</returns>
    public Task<bool> Delete(Guid id);

    /// <summary>
    /// Gets the range of entities.
    /// </summary>
    /// <param name="startPoint">The start point.</param>
    /// <param name="count">The count.</param>
    /// <returns>A range of entities of size <paramref name="count"/> starting from <paramref name="startPoint"/>.</returns>
    public Task<IEnumerable<T>> GetRange(int startPoint, int count);
}
