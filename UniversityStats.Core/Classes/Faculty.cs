using System.Collections.Generic;

namespace UniversityStats.Classes;

public class Faculty
{
    public int Id { get; set; } // Primary Key
    public required string Name { get; set; }
    public int GroupCount { get; set; }
    public List<Department> Departments { get; set; } = new List<Department>();
    public List<Specialty> Specialties { get; set; } = new List<Specialty>();
}

