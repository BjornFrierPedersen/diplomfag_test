using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApplication.Models;

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    public required int Credits { get; set; }
    
    // Navigational properties
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public override string ToString()
    {
       return $"Id: {Id} Name: {Name}";
    }
}