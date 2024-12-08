using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityStats.Infrastructure.Entities;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [ForeignKey(nameof(University))]
    public int UniversityId { get; set; }

    public University University { get; set; }

    public ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
}
