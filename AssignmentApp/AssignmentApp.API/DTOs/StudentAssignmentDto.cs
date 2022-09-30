using AssignmentApp.Data.Entities;

namespace AssignmentApp.API.DTOs;

public class StudentAssignmentDto
{
    public int AssignmentId { get; set; }
    public UserDto Student { get; set; }
    public bool Submitted { set; get; }
    public double? Grade { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public string SubmitFile { get; set; }
    public string Feedback { get; set; }
}