﻿namespace TeamService.BusinessLogic.Interfaces;

public interface IService<T> where T : class
{
    public bool TryGetById(Guid id, out T entity);

    public Task<T> Create(T entity);

    public Task<T> Update(T entity);

    public Task<bool> Delete(int id);

    public Task<IEnumerable<T>> GetRange(int startPoint, int count);
}
