﻿// <auto-generated />
using System;
using FluentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FluentAPI.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FluentAPI.Model.AcademicRecord", b =>
                {
                    b.Property<int>("AcademicRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicRecordId"));

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("DATE");

                    b.Property<string>("EnrollmentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR(50)")
                        .HasColumnName("EnrollmentNumber");

                    b.HasKey("AcademicRecordId");

                    b.HasIndex("EnrollmentNumber")
                        .HasDatabaseName("IX_AcademicRecords_EnrollmentNumber");

                    b.ToTable("AcademicRecords", (string)null);
                });

            modelBuilder.Entity("FluentAPI.Model.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("CourseName");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Courses_Name");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("FluentAPI.Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("AcademicRecordId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("StudentName");

                    b.HasKey("StudentId");

                    b.HasIndex("AcademicRecordId")
                        .IsUnique();

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Students_Name");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("FluentAPI.Model.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId", "CourseId")
                        .IsUnique();

                    b.ToTable("StudentCourses", (string)null);
                });

            modelBuilder.Entity("FluentAPI.Model.StudyMaterial", b =>
                {
                    b.Property<int>("StudyMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudyMaterialId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR(500)")
                        .HasColumnName("MaterialDescription");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("MaterialTitle");

                    b.HasKey("StudyMaterialId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudyMaterials", (string)null);
                });

            modelBuilder.Entity("FluentAPI.Model.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("TeacherName");

                    b.HasKey("TeacherId");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Teachers_Name");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("FluentAPI.Model.Course", b =>
                {
                    b.HasOne("FluentAPI.Model.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("FluentAPI.Model.Student", b =>
                {
                    b.HasOne("FluentAPI.Model.AcademicRecord", "AcademicRecord")
                        .WithOne("Student")
                        .HasForeignKey("FluentAPI.Model.Student", "AcademicRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicRecord");
                });

            modelBuilder.Entity("FluentAPI.Model.StudentCourse", b =>
                {
                    b.HasOne("FluentAPI.Model.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FluentAPI.Model.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FluentAPI.Model.StudyMaterial", b =>
                {
                    b.HasOne("FluentAPI.Model.Course", "Course")
                        .WithMany("StudyMaterials")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("FluentAPI.Model.AcademicRecord", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("FluentAPI.Model.Course", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("StudyMaterials");
                });

            modelBuilder.Entity("FluentAPI.Model.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("FluentAPI.Model.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
