using System;
using System.Collections.Generic;

namespace FluentAPI.Model;

public class AcademicRecord
{
    public int AcademicRecordId { get; set; }
    public string EnrollmentNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }

    // One-to-One relationship: AcademicRecord -> Student
    public Student Student { get; set; }
}