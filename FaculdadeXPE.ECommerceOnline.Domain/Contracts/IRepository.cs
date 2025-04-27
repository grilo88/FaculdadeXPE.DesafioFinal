﻿namespace FaculdadeXPE.ECommerceOnline.Domain.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<bool> SaveChangesAsync();
    }
}
