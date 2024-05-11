using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task1.Entities;

namespace task1.Data.Configurations
{
    public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
               .ToTable("Courses");

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
                .Property(t => t.Description)
                .HasMaxLength(150)
                .HasDefaultValue(null);

            builder
                .HasOne(t => t.Teacher)
                .WithMany(c => c.Courses);
        }
    }
}
