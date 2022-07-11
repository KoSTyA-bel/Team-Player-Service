using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.DataAccess.Contexts;

namespace TeamService.DataAccess.Repositories;

public class PlayerRepository : IRepository<Player>
{
    private readonly TeamContext _context;

    public PlayerRepository(TeamContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task Create(Player entity)
    {
        _context.Add(entity);
        return Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        var player = await this.GetById(id);
        _context.Player.Remove(player);
    }

    public Task<Player> GetById(Guid id) => _context.Player.FirstAsync(p => p.Id == id);

    public Task<IEnumerable<Player>> GetRange(int startPoint, int count)
    {
        throw new NotImplementedException();
    }

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
