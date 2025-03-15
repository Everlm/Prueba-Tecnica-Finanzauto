using Finanzauto.Domain.Entities;
using Finanzauto.Infrastructure.Persistences.Contexts;
using Finanzauto.Infrastructure.Persistences.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Finanzauto.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinanzautoContext _context;
        public IGenericRepository<Student> _student = null!;

        public UnitOfWork(FinanzautoContext context, IConfiguration configuration)
        {
            _context = context;
        }

        public IGenericRepository<Student> Student => _student ?? new GenericRepository<Student>(_context);


        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
