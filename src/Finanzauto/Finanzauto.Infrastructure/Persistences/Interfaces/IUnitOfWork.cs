using Finanzauto.Domain.Entities;

namespace Finanzauto.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Student> Student { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
