using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;

namespace TeamService.BusinessLogic.Services;

public class PlayerService : IService<Player>
{
    private readonly IRepository<Player> _repository;
    private readonly IDataContext _dataContext;

    public PlayerService(IRepository<Player> repository, IDataContext dataContext)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
    }

    public async Task<Player> Create(Player entity)
    {
        await _repository.Create(entity);
        await _dataContext.SaveChangesAsync(new CancellationToken());
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        await _repository.Delete(id);
        await _dataContext.SaveChangesAsync(new CancellationToken());
        return true;
    }

    public Task<IEnumerable<Player>> GetRange(int startPoint, int count) => _repository.GetRange(startPoint, count);

    public bool TryGetById(Guid id, out Player entity)
    {
        entity = _repository.GetById(id).GetAwaiter().GetResult();

        return entity != null;
    }

    public async Task<Player> Update(Player entity)
    {
        await _repository.Update(entity);
        await _dataContext.SaveChangesAsync(new CancellationToken());
        return entity;
    }
}
