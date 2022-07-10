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

    public Task<Team> Create(Team entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Team>> GetRange(int startPoint, int count)
    {
        throw new NotImplementedException();
    }

    public bool TryGetById(Guid id, out Team entity)
    {
        throw new NotImplementedException();
    }

    public Task<Team> Update(Team entity)
    {
        throw new NotImplementedException();
    }
}
