﻿using Finanzauto.Domain.Entities;
using System.Linq.Expressions;

namespace Finanzauto.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllQueryable();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetSelectAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
    }
}
