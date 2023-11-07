using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApplication.Models;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(50)]
    public required string LastName { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    
    // Navigational properties
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public override string ToString()
    {
        return $"Id: {Id} Name: {FirstName} {LastName}";
    }
}