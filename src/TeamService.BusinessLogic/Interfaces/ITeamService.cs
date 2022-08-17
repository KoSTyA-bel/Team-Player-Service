using TeamService.BusinessLogic.Entities;

namespace TeamService.BusinessLogic.Interfaces;

public interface ITeamService
{
    /// <summary>
    /// Tries the get team by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="team">Team.</param>
    /// <returns>True if database contains entity with specific id, false in other cases.</returns>
    public bool TryGetById(Guid id, out Team team);

    /// <summary>
    /// Creates the specified team.
    /// </summary>
    /// <param name="team">Team.</param>
    /// <returns>Team.</returns>
    public Task<Team> Create(Team team);

    /// <summary>
    /// Updates the specified team.
    /// </summary>
    /// <param name="team">Team.</param>
    /// <returns>Team.</returns>
    public Task<Team> Update(Team team);

    /// <summary>
    /// Deletes the team with specified identifier.
    /// </summary>
    /// <param name="teamId">The identifier.</param>
    /// <returns>True if the deletion was successful, false in other cases.</returns>
    public Task<bool> Delete(Guid teamId);

    /// <summary>
    /// Gets the range of teams.
    /// </summary>
    /// <param name="startPoint">The start point.</param>
    /// <param name="count">The count.</param>
    /// <returns>A range of entities of size <paramref name="count"/> starting from <paramref name="startPoint"/>.</returns>
    public Task<IEnumerable<Team>> GetRange(int startPoint, int count);
}
