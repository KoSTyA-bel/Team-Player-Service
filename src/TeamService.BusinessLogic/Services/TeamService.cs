using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;

namespace TeamService.BusinessLogic.Services;

/// <summary>
/// Specific implementation <see cref="ITeamService}"/>.
/// </summary>
/// <seealso cref="TeamService.BusinessLogic.Interfaces.ITeamService"/>
/// <seealso cref="TeamService.BusinessLogic.Interfaces.ITeamService&gt;TeamService.BusinessLogic.Entities.Team&gt;" />
public class TeamService : ITeamService
{
    private readonly ITeamRepository _repository;
    private readonly IDataContext _dataContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="TeamService"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="dataContext">The data context.</param>
    /// <exception cref="System.ArgumentNullException">When <paramref name="dataContext"/> or <paramref name="repository"/> is null.</exception>
    public TeamService(ITeamRepository repository, IDataContext dataContext)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
    }

    /// <inheritdoc/>
    public async Task<Team> Create(Team entity)
    {
        await _repository.Create(entity);
        await _dataContext.SaveChangesAsync(new CancellationToken());
        return entity;
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(Guid id)
    {
        await _repository.Delete(id);
        await _dataContext.SaveChangesAsync(new CancellationToken());
        return true;
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Team>> GetRange(int startPoint, int count) => _repository.GetRange(startPoint, count);

    /// <inheritdoc/>
    public async Task<Team> Update(Team entity)
    {
        await _repository.Update(entity);
        await _dataContext.SaveChangesAsync(new CancellationToken());
        return entity;
    }

    /// <inheritdoc/>
    public bool TryGetById(Guid id, out Team entity)
    {
        entity = _repository.GetById(id).GetAwaiter().GetResult();

        return entity != null;
    }
}
