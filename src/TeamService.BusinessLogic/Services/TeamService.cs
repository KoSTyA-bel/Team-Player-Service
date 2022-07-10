using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;

namespace TeamService.BusinessLogic.Services;

public class TeamService : IService<Team>
{
    private readonly IRepository<Team> _repository;
    private readonly IDataContext _dataContext;

    public TeamService(IRepository<Team> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Team> Create(Team entity)
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

    public Task<IEnumerable<Team>> GetRange(int startPoint, int count) => _repository.GetRange(startPoint, count);

    public async Task<Team> Update(Team entity)
    {
        await _repository.Update(entity);
        await _dataContext.SaveChangesAsync(new CancellationToken());
        return entity;
    }

    public bool TryGetById(Guid id, out Team entity)
    {
        entity = _repository.GetById(id).GetAwaiter().GetResult();

        return entity != null;
    }
}
