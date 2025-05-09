﻿namespace CouchChefBLL.Interfaces;

public interface ICrud<T> where T : class
{
    Task<int> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteByIdAsync(int id);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}
