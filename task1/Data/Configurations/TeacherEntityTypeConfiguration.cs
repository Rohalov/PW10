using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task1.Entities;

namespace task1.Data.Configurations
{
    public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
               .ToTable("Teachers");

            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Id)
                .IsRequired();

            builder
                .Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(t => t.Surname)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(t => t.Email)
                .HasMaxLength(150);

            builder
                .HasMany(t => t.Courses)
                .WithOne(t => t.Teacher)
                .HasForeignKey(t => t.TeacherId)
                .IsRequired();
        }
    }
}
