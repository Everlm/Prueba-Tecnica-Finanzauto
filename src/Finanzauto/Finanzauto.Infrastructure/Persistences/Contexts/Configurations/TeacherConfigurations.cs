using Finanzauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Infrastructure.Persistences.Contexts.Configurations
{
    public class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            {
                builder.ToTable("Teachers");

                builder.HasKey(t => t.Id);

                builder.Property(s => s.Id).ValueGeneratedOnAdd();

                builder.Property(t => t.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(t => t.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(t => t.State)
                    .HasDefaultValue(1);

                
                builder.HasMany(t => t.Courses)
                    .WithOne(c => c.Teacher)
                    .HasForeignKey(c => c.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict);

            }
        }
    }
}
