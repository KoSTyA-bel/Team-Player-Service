namespace TeamService.BusinessLogic.Interfaces;

/// <summary>
/// Provides methods that should be implemented in the data context.
/// </summary>
public interface IDataContext
{
    /// <summary>
    /// Saves the changes asynchronous.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns>Task of saving changes in the database.</returns>
    public Task SaveChangesAsync(CancellationToken token);
}
