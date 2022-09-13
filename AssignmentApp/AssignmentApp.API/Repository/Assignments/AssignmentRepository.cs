using AssignmentApp.API.Repository.Assignments.DTOs;
using AssignmentApp.API.Utilities.Exception;
using AssignmentApp.Data.EF;
using AssignmentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace AssignmentApp.API.Repository.Assignments;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly AssignmentAppDbContext _context;
    public AssignmentRepository(AssignmentAppDbContext context)
    {
        _context = context;
    }

    public async Task<Assignment> CreateAssignment(Assignment createAssignment)
    {
        var assignment = new Assignment()
        {
            ClassId = createAssignment.ClassId,
            CreateAt = createAssignment.CreateAt,
            DueTo = createAssignment.DueTo,
            Title = createAssignment.Title,
            Content = createAssignment.Content,
        };
        await _context.Assignments.AddAsync(assignment);
        await _context.SaveChangesAsync();
        return assignment;
    }

    public async Task<Assignment> UpdateAssignment(Assignment updateAssignment , int id)
    {
        var existingAssignment = await _context.Assignments.FindAsync(id);
        if (existingAssignment == null)
        {
            throw new CustomException($"This assignment id is not found : {id}");
            return null;
        }

        existingAssignment.ClassId = updateAssignment.ClassId;
        existingAssignment.CreateAt = updateAssignment.CreateAt;
        existingAssignment.DueTo = updateAssignment.DueTo;
        existingAssignment.Content = updateAssignment.Content;
        existingAssignment.Title = updateAssignment.Title;
        await _context.SaveChangesAsync();
        return existingAssignment;
    }

    public async Task<Assignment> DeleteAssignment(int assignmentId)
    {
        var assignment = await _context.Assignments.FindAsync(assignmentId);
        if (assignment == null)
        {
            throw new CustomException($"This assignment id is not found : {assignmentId}");
        }
        _context.Assignments.Remove(assignment);
        await _context.SaveChangesAsync();
        return assignment;
    }

    public Task<List<AssignmentDto>>  GetAllByClass(int classId)
    {
        throw new NotImplementedException();
    }
    
    public async Task<List<Assignment>>  GetAll()
    {
        return await _context.Assignments.ToListAsync();
    }

    public async Task<Assignment>  GetAssignment(int id)
    {
        var assignment = await _context.Assignments.FindAsync(id);
        if (assignment == null)
        {
            throw new CustomException($"This assignment id is not found : {id}");
        }

        return assignment;
    }
}