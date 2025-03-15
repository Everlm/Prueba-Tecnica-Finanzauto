using Finanzauto.Domain.Entities;
using Finanzauto.Infrastructure.Persistences.Contexts;
using Finanzauto.Infrastructure.Persistences.Interfaces;
using Finanzauto.Utilities.Static;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finanzauto.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly FinanzautoContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(FinanzautoContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }


        public IQueryable<T> GetAllQueryable()
        {
            var getAllQueryable = GetEntityQuery();
            return getAllQueryable;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity
                .Where(x => x.State.Equals((int)StateTypes.Active))
                .AsNoTracking()
                .ToListAsync();

            return getAll;
        }

        public async Task<IEnumerable<T>> GetSelectAsync()
        {
            var getAll = await _entity
               .Where(x => x.State
                   .Equals((int)StateTypes.Active))
               .AsNoTracking()
               .ToListAsync();

            return getAll;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var GetById = await _entity!.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

            return GetById!;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Update(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            _context.Remove(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if (filter != null) query = query.Where(filter);

            return query;
        }


    }
}
