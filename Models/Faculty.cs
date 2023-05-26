using System.ComponentModel.DataAnnotations;

namespace WDA_PE.Models;

public class Faculty
{
    [Key] public Guid FacultyId { get; set; }

    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Name { get; set; }
}