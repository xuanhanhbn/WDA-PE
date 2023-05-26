using System.ComponentModel.DataAnnotations;

namespace WDA_PE.Models;

public class Classroom
{
    [Key]
    public Guid ClassroomId { get; set; }
    [Required]
    [StringLength(5, ErrorMessage = "RoomNo cannot be longer than 5 characters.")]
    public string RoomNo { get; set; }
}