using AssignmentApp.API.Repository.Assignments.DTOs;
using AssignmentApp.Data.Entities;

namespace AssignmentApp.API.Repository.Assignments;

public interface IAssignmentRepository
{
    Task<Assignment> CreateAssignment(Assignment createAssignment);
    Task<Assignment> UpdateAssignment(Assignment updateAssignment , int id);
    Task<Assignment> DeleteAssignment(int assignmentId);
    Task<List<AssignmentDto>> GetAllByClass(int classId);
    Task<Assignment> GetAssignment(int id);
    Task<List<Assignment>> GetAll();
}

