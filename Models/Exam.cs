using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WDA_PE.Models;

public class Exam
{
    [Key]
    public Guid ExamId { get; set; }
    [DataType(DataType.Date)] public DateTime DateTime { get; set; }
    public int Duration { get; set; }
    [ForeignKey("ClassroomId")] public Classroom Classroom { get; set; }
    [ForeignKey("FacultyId")] public Faculty Faculty { get; set; }
    [ForeignKey("SubjectId")] public Subject Subject { get; set; }
    
}