﻿namespace ECommerce.Domain.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(long id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(long id);

        Task<bool> SaveChangesAsync();
    }
}
