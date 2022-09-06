namespace AssignmentApp.Data.Entities;

public class Assignment
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // user tạo assignment
    public Guid ClassId { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime DueTo { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}