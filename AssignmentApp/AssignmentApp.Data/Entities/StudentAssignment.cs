namespace AssignmentApp.Data.Entities;

public class StudentAssignment
{
    public Guid AssignmentId { get; set; }
    public Guid StudentId { get; set; }
    public bool Submitted { set; get; }
    public double Grade { get; set; }
    public string Feedback { get; set; }
}