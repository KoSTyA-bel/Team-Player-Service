using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.DataAccess.Contexts;

namespace TeamService.DataAccess.Repositories;

/// <summary>
/// Specific implementation <see cref="IRepository{T}"/>.
/// </summary>
/// <seealso cref="TeamService.BusinessLogic.Interfaces.IPlayerRepository"/>
/// <seealso cref="TeamService.BusinessLogic.Entities.Player"/>
public class PlayerRepository : IPlayerRepository
{
    private readonly TeamContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerRepository"/> class.
    /// </summary>
    /// <param name="context">The team context.</param>
    /// <exception cref="System.ArgumentNullException">When <paramref name="context"/> is null.</exception>
    public PlayerRepository(TeamContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public Task Create(Player entity)
    {
        _context.Add(entity);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public async Task Delete(Guid id)
    {
        var player = await this.GetById(id);
        _context.Players.Remove(player);
    }

    /// <inheritdoc/>
    public Task<Player> GetById(Guid id) => _context.Players.FirstAsync(p => p.Id == id);

    /// <inheritdoc/>
    public Task<IEnumerable<Player>> GetRange(int startPoint, int count)
    {
        if (startPoint < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startPoint));
        }

        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        return Task.FromResult((IEnumerable<Player>)_context.Players.Skip(startPoint).Take(count).ToArray());
    }

    /// <inheritdoc/>
    public Task Update(Player entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Attach(entity);
        }

        _context.Entry(entity).State = EntityState.Modified;

        return Task.CompletedTask;
    }
}
