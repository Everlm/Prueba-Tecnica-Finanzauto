using Finanzauto.Domain.Entities;
using Finanzauto.Infrastructure.Persistences.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Finanzauto.Infrastructure.Persistences.Contexts
{
    public partial class FinanzautoContext : IdentityDbContext
    {

        public FinanzautoContext(DbContextOptions<FinanzautoContext> options) : base(options)
        {
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            FinanzautoContextSeed.Seed(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
