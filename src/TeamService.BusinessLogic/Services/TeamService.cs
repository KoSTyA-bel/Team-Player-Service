using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;

namespace TeamService.BusinessLogic.Services;

public class TeamService : IService<Team>
{
    private readonly IRepository<Team> _repository;

    public TeamService(IRepository<Team> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public Task<Team> Create(Team entity) => _repository.Create(entity);

    public Task<bool> Delete(Guid id) => _repository.Delete(id);

    public Task<IEnumerable<Team>> GetRange(int startPoint, int count) => _repository.GetRange(startPoint, count);

    public Task<Team> Update(Team entity) => _repository.Update(entity);

    public bool TryGetById(Guid id, out Team entity)
    {
        entity = _repository.GetById(id).GetAwaiter().GetResult();

        return entity != null;
    }
}
