using FluentAPI.Model;
using FluentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentAPI.Data.Mappings;

public class CourseMap : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(c => c.CourseId);
        builder.Property(c => c.CourseId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();


        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("CourseName")
            .HasColumnType("VARCHAR(100)");

        // Many-to-Many: Course -> Student (StudentCourse)
        builder.HasMany(c => c.StudentCourses)
            .WithOne(sc => sc.Course)
            .HasForeignKey(sc => sc.CourseId);

        // One-to-Many: Course -> StudyMaterial
        builder.HasMany(c => c.StudyMaterials)
            .WithOne(sm => sm.Course)
            .HasForeignKey(sm => sm.CourseId);

        // One-to-Many: Teacher -> Courses
        builder.HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(c => c.Name)
            .HasDatabaseName("IX_Courses_Name");
    }
}