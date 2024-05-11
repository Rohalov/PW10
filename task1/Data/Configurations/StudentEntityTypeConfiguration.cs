using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task1.Entities;

namespace task1.Data.Configurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .ToTable("Students");

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
                .WithMany(c => c.Students);

            builder
                .HasMany(t => t.Grades)
                .WithOne(g => g.Student)
                .HasForeignKey(x => x.StudentId)
                .IsRequired();
        }
    }
}
