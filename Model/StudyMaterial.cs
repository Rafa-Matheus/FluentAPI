using System;
using System.Collections.Generic;

namespace FluentAPI.Model;

public class StudyMaterial
{
    public int StudyMaterialId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    // One-to-Many relationship: Course -> StudyMaterial
    public int CourseId { get; set; }
    public Course Course { get; set; }
}