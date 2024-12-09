using FluentAPI.Model;
using FluentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentAPI.Data.Mappings;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        
        builder.HasKey(x => x.StudentId);
        builder.Property(x => x.StudentId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("StudentName")
            .HasColumnType("NVARCHAR(100)");
        
        // One-to-One: Student -> AcademicRecord
        builder.HasOne(s => s.AcademicRecord)
            .WithOne(ar => ar.Student)
            .HasForeignKey<Student>(s => s.AcademicRecordId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // One-to-Many: Student -> Course (StudentCourse)
        builder.HasMany(s => s.StudentCourses)
            .WithOne(sc => sc.Student)
            .HasForeignKey(sc => sc.StudentId);
        
        builder.HasIndex(s => s.Name)
            .HasDatabaseName("IX_Students_Name");
    }
}