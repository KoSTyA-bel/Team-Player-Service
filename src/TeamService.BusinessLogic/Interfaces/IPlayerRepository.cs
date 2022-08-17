using TeamService.BusinessLogic.Entities;

namespace TeamService.BusinessLogic.Interfaces;

public interface IPlayerRepository
{
    /// <summary>
    /// Gets playet by identifier.
    /// </summary>
    /// <param name="playerId">The identifier.</param>
    /// <returns>Player with a specific id.</returns>
    public Task<Player> GetById(Guid playerId);

    /// <summary>
    /// Creates the specified player.
    /// </summary>
    /// <param name="player">Player.</param>
    /// <returns>Task of writing an object to the database.</returns>
    public Task Create(Player player);

    /// <summary>
    /// Updates the specified player.
    /// </summary>
    /// <param name="entity">Player.</param>
    /// <returns>Task of updating an object in the database.</returns>
    public Task Update(Player player);

    /// <summary>
    /// Deletes player with specified identifier.
    /// </summary>
    /// <param name="entityId">Player id.</param>
    /// <returns>Task of deleting an object in the database</returns>
    public Task Delete(Guid playerId);

    /// <summary>
    /// Gets the range of players.
    /// </summary>
    /// <param name="startPoint">The start point.</param>
    /// <param name="count">The count.</param>
    /// <returns>A range of entities of size <paramref name="count"/> starting from <paramref name="startPoint"/>.</returns>
    public Task<IEnumerable<Player>> GetRange(int startPoint, int count);
}
