using FluentAPI.Model;
using FluentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentAPI.Data.Mappings;

public class TeacherMap : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(t => t.TeacherId);
        builder.Property(t => t.TeacherId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("TeacherName")
            .HasColumnType("NVARCHAR(100)");

        // One-to-Many: Teacher -> Courses
        builder.HasMany(t => t.Courses)
            .WithOne(c => c.Teacher)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(t => t.Name)
            .HasDatabaseName("IX_Teachers_Name");
    }
}