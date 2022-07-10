using TeamService.BusinessLogic.Interfaces;
using TeamService.BusinessLogic.Entities;

namespace TeamService.DataAccess.Contexts;

public class TeamDataContext : IDataContext
{
    private readonly TeamContext _context;

    public TeamDataContext(TeamContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task SaveChangesAsync(CancellationToken token) => _context.SaveChangesAsync(token);
}
