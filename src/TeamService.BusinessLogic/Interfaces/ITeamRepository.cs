using TeamService.BusinessLogic.Entities;

namespace TeamService.BusinessLogic.Interfaces;

public interface ITeamRepository
{
    /// <summary>
    /// Gets team by identifier.
    /// </summary>
    /// <param name="teamId">The identifier.</param>
    /// <returns>Team with a specific id.</returns>
    public Task<Team> GetById(Guid teamId);

    /// <summary>
    /// Creates the specified team.
    /// </summary>
    /// <param name="team">Team.</param>
    /// <returns>Task of writing an object to the database.</returns>
    public Task Create(Team team);

    /// <summary>
    /// Updates the specified team.
    /// </summary>
    /// <param name="team">Team.</param>
    /// <returns>Task of updating an object in the database.</returns>
    public Task Update(Team team);

    /// <summary>
    /// Deletes team with specified identifier.
    /// </summary>
    /// <param name="teamId">Team id.</param>
    /// <returns>Task of deleting an object in the database</returns>
    public Task Delete(Guid teamId);

    /// <summary>
    /// Gets the range of teams.
    /// </summary>
    /// <param name="startPoint">The start point.</param>
    /// <param name="count">The count.</param>
    /// <returns>A range of entities of size <paramref name="count"/> starting from <paramref name="startPoint"/>.</returns>
    public Task<IEnumerable<Team>> GetRange(int startPoint, int count);
}
