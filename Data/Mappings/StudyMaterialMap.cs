using FluentAPI.Model;
using FluentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentAPI.Data.Mappings;

public class StudyMaterialMap : IEntityTypeConfiguration<StudyMaterial>
{
    public void Configure(EntityTypeBuilder<StudyMaterial> builder)
    {
        builder.ToTable("StudyMaterials");
        
        builder.HasKey(x => x.StudyMaterialId);
        builder.Property(x => x.StudyMaterialId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("MaterialTitle")
            .HasColumnType("NVARCHAR(100)");
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("MaterialDescription")
            .HasColumnType("NVARCHAR(500)");

        builder.HasOne(sm => sm.Course)
            .WithMany(c => c.StudyMaterials)
            .HasForeignKey(sm => sm.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}