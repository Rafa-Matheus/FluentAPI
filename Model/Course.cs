using System;
using System.Collections.Generic;

namespace FluentAPI.Model;

public class Course
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    
    // Many-to-Many relationship: Course -> Student
    public ICollection<StudentCourse> StudentCourses { get; set; }

    // One-to-Many relationship: Course -> StudyMaterials
    public ICollection<StudyMaterial> StudyMaterials { get; set; }
    
    // One-to-Many relationship: Teacher -> Courses
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}