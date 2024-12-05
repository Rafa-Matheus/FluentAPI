using System;
using System.Collections.Generic;

namespace FluentAPI.Model;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    
    // One-to-One relationship: Student -> AcademicRecord
    public int AcademicRecordId { get; set; }
    public AcademicRecord AcademicRecord { get; set; }

    // Many-to-Many relationship: Student -> Course
    public ICollection<StudentCourse> StudentCourses { get; set; }
}