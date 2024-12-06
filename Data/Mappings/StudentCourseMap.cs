using FluentAPI.Model;
using FluentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentAPI.Data.Mappings;

public class StudentCourseMap : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.ToTable("StudentCourses");

		builder.HasKey(sc => sc.Id);
		builder.Property(sc => sc.Id)
			.ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.HasIndex(sc => new { sc.StudentId, sc.CourseId })
			.IsUnique();

        // Many-to-Many: Student -> Course
        builder.HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId);

        builder.HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId);
    }
}