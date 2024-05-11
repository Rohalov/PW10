using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task1.Entities;

namespace task1.Data.Configurations
{
    public class GradeEntityTypeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder
               .ToTable("Grades");

            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Id)
                .IsRequired();

            builder
                .Property(t => t.GradeValue)
                .IsRequired();

            builder
                .HasOne(t => t.Student)
                .WithMany(t => t.Grades)
                .HasForeignKey(t => t.StudentId)
                .IsRequired();

            builder
                .HasOne(t => t.Course)
                .WithMany(t => t.Grades)
                .HasForeignKey(t => t.CourseId)
                .IsRequired();
        }
    }
}
