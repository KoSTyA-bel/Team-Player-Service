using TeamService.BusinessLogic.Entities;

namespace TeamService.BusinessLogic.Interfaces;

public interface IPlayerService
{
    /// <summary>
    /// Tries the get player by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="team">Player.</param>
    /// <returns>True if database contains entity with specific id, false in other cases.</returns>
    public bool TryGetById(Guid id, out Player player);

    /// <summary>
    /// Creates the specified player.
    /// </summary>
    /// <param name="player">Player.</param>
    /// <returns>Player.</returns>
    public Task<Player> Create(Player player);

    /// <summary>
    /// Updates the specified player.
    /// </summary>
    /// <param name="player">Player.</param>
    /// <returns>Player.</returns>
    public Task<Player> Update(Player player);

    /// <summary>
    /// Deletes the player with specified identifier.
    /// </summary>
    /// <param name="playerId">The identifier.</param>
    /// <returns>True if the deletion was successful, false in other cases.</returns>
    public Task<bool> Delete(Guid playerId);

    /// <summary>
    /// Gets the range of players.
    /// </summary>
    /// <param name="startPoint">The start point.</param>
    /// <param name="count">The count.</param>
    /// <returns>A range of entities of size <paramref name="count"/> starting from <paramref name="startPoint"/>.</returns>
    public Task<IEnumerable<Player>> GetRange(int startPoint, int count);
}
