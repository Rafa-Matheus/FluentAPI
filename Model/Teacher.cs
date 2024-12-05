using System;
using System.Collections.Generic;

namespace FluentAPI.Model;

public class Teacher
{
    public int TeacherId { get; set; }
    public string Name { get; set; }

    // One-to-Many relationship: Teacher -> Courses
    public ICollection<Course> Courses { get; set; }
}