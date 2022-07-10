namespace TeamService.BusinessLogic.Interfaces;

public interface IRepository<T> where T : class
{
    public Task<T> GetById(Guid id);

    public Task<T> Create(T entity);

    public Task<T> Update(T entity);

    public Task<bool> Delete(Guid entity);

    public Task<IEnumerable<T>> GetRange(int startPoint, int count);
}
