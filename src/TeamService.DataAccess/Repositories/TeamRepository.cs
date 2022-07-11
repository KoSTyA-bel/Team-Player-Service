using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.DataAccess.Contexts;

namespace TeamService.DataAccess.Repositories;

public class TeamRepository : IRepository<Team>
{
    private readonly TeamContext _context;

    public TeamRepository(TeamContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task Create(Team entity)
    {
        _context.Add(entity);
        return Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        var team = await this.GetById(id);
        _context.Teams.Remove(team);
    }

    public Task<Team> GetById(Guid id) => _context.Teams.FirstAsync(t => t.Id == id);

    public Task<IEnumerable<Team>> GetRange(int startPoint, int count)
    {
        throw new NotImplementedException();
    }

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
