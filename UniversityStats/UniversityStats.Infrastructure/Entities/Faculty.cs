using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityStats.Infrastructure.Entities;

public class Faculty
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }

    public Department Department { get; set; }

    public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
}
