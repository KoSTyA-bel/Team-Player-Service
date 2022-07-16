using TeamService.BusinessLogic.Interfaces;

namespace TeamService.DataAccess.Contexts;

/// <summary>
/// Specific implementation <see cref="IDataContext"/>.
/// </summary>
/// <seealso cref="TeamService.BusinessLogic.Interfaces.IDataContext" />
public class TeamDataContext : IDataContext
{
    private readonly TeamContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="TeamDataContext"/> class.
    /// </summary>
    /// <param name="context">The team context.</param>
    /// <exception cref="System.ArgumentNullException">When <paramref name="context"/> is null.</exception>
    public TeamDataContext(TeamContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public Task SaveChangesAsync(CancellationToken token) => _context.SaveChangesAsync(token);
}
