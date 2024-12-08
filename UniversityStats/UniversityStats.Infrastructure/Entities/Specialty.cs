using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityStats.Infrastructure.Entities;

public class Specialty
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [ForeignKey(nameof(Faculty))]
    public int FacultyId { get; set; }

    public Faculty Faculty { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}
