using Microsoft.EntityFrameworkCore;
using FluentAPI.Model;
using FluentAPI.Data.Mappings;

namespace FluentAPI.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options)
    {
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<AcademicRecord> AcademicRecords { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudyMaterial> StudyMaterials { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AcademicRecordMap());
        modelBuilder.ApplyConfiguration(new CourseMap());
        modelBuilder.ApplyConfiguration(new StudentCourseMap());
        modelBuilder.ApplyConfiguration(new StudentMap());
        modelBuilder.ApplyConfiguration(new StudyMaterialMap());
        modelBuilder.ApplyConfiguration(new TeacherMap());
    }
}