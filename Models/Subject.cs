using System.ComponentModel.DataAnnotations;

namespace WDA_PE.Models;

public class Subject
{
    [Key]
    public Guid SubjectId { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "RoomNo cannot be longer than 50 characters.")]
    public string SubjectName { get; set; }
}