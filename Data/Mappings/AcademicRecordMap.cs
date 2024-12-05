using FluentAPI.Model;
using FluentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentAPI.Data.Mappings;

public class AcademicRecordMap : IEntityTypeConfiguration<AcademicRecord>
{
    public void Configure(EntityTypeBuilder<AcademicRecord> builder)
    {
        builder.ToTable("AcademicRecords");

        builder.HasKey(x => x.AcademicRecordId);
        builder.Property(ar => ar.AcademicRecordId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.EnrollmentNumber)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("EnrollmentNumber")
            .HasColumnType("VARCHAR(50)");

        builder.Property(x => x.EnrollmentDate)
            .IsRequired()
            .HasColumnType("DATE");

        // One-to-One: AcademicRecord -> Student
        builder.HasOne(ar => ar.Student)
            .WithOne(s => s.AcademicRecord)
            .HasForeignKey<Student>(s => s.AcademicRecordId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(ar => ar.EnrollmentNumber)
            .HasDatabaseName("IX_AcademicRecords_EnrollmentNumber");
    }
}