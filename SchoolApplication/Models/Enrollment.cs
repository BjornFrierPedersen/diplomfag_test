using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApplication.Models;

public class Enrollment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey(nameof(Student))]
    public required int StudentId { get; set; }
    [ForeignKey(nameof(Course))]
    public required int CourseId { get; set; }
    [MaxLength(2)]
    public required string Grade { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} StudentId: {StudentId}, CourseId: {CourseId}, Grade: {Grade}";
    }
}