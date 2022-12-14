using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;

namespace TeamService.BusinessLogic.Services;

/// <summary>
/// Specific implementation <see cref="IPlayerService"/>.
/// </summary>
public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;
    private readonly IDataContext _dataContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerService"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="dataContext">The data context.</param>
    /// <exception cref="System.ArgumentNullException">When <paramref name="dataContext"/> or <paramref name="repository"/> is null.</exception>
    public PlayerService(IPlayerRepository repository, IDataContext dataContext)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
    }

    /// <inheritdoc/>
    public async Task<Player> Create(Player entity)
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
    public Task<IEnumerable<Player>> GetRange(int startPoint, int count) => _repository.GetRange(startPoint, count);

    /// <inheritdoc/>
    public bool TryGetById(Guid id, out Player entity)
    {
        entity = _repository.GetById(id).GetAwaiter().GetResult();

        return entity != null;
    }

    /// <inheritdoc/>
    public async Task<Player> Update(Player entity)
    {
        await _repository.Update(entity);
        await _dataContext.SaveChangesAsync(new CancellationToken());
        return entity;
    }
}
