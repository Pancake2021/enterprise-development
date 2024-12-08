using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityStats.Infrastructure.Entities;

public class Group
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [ForeignKey(nameof(Specialty))]
    public int SpecialtyId { get; set; }

    public Specialty Specialty { get; set; }
}
