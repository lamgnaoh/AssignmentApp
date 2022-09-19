namespace AssignmentApp.API.DTOs;

public class StudentAssignmentDto
{
    public int AssignmentId { get; set; }
    public int StudentId { get; set; }
    public bool Submitted { set; get; }
    public double? Grade { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public string Feedback { get; set; }
}