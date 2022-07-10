namespace TeamService.BusinessLogic.Interfaces;

public interface IRepository<T> where T : class
{
    public Task<T> GetById(Guid id);

    public Task Create(T entity);

    public Task Update(T entity);

    public Task Delete(Guid entity);

    public Task<IEnumerable<T>> GetRange(int startPoint, int count);
}
