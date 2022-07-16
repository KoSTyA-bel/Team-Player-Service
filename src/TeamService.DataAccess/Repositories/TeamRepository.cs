using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.DataAccess.Contexts;

namespace TeamService.DataAccess.Repositories;

/// <summary>
/// Specific implementation <see cref="IRepository{T}"/>.
/// </summary>
/// <seealso cref="TeamService.BusinessLogic.Interfaces.IRepository&lt;TeamService.BusinessLogic.Entities.Team;" />
public class TeamRepository : IRepository<Team>
{
    private readonly TeamContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="TeamRepository"/> class.
    /// </summary>
    /// <param name="context">The team context.</param>
    /// <exception cref="System.ArgumentNullException">When <paramref name="context"/> is null.</exception>
    public TeamRepository(TeamContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public Task Create(Team entity)
    {
        _context.Add(entity);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public async Task Delete(Guid id)
    {
        var team = await this.GetById(id);
        _context.Teams.Remove(team);
    }

    /// <inheritdoc/>
    public Task<Team> GetById(Guid id) => _context.Teams.FirstAsync(t => t.Id == id);

    /// <inheritdoc/>
    public Task<IEnumerable<Team>> GetRange(int startPoint, int count)
    {
        if (startPoint <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startPoint));
        }

        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        return Task.FromResult((IEnumerable<Team>)_context.Teams.Skip(startPoint).Take(count).ToArray());
    }

    /// <inheritdoc/>
    public Task Update(Team entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Attach(entity);
        }

        _context.Entry(entity).State = EntityState.Modified;

        return Task.CompletedTask;
    }
}
