using AssignmentApp.API.Utilities.Exception;
using AssignmentApp.Data.EF;
using AssignmentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace AssignmentApp.API.Repository.Classes;

public class ClassRepository : IClassRepository
{
    private readonly AssignmentAppDbContext _context;

    public ClassRepository(AssignmentAppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Class>> GetAll()
    {
        return await _context.Classes.ToListAsync();
    }

    public async Task<Class> CreateClass(Class createClass)
    {
        var newClass = new Class()
        {
            Name = createClass.Name,
            CreateAt = DateTime.Now
        };
        await _context.Classes.AddAsync(newClass);
        await _context.SaveChangesAsync();
        return newClass;
    }

    public async Task<Class> UpdateClass(Class updateClass , int classId)
    {
        var existingClass = await _context.Classes.FindAsync(classId);
        if (existingClass == null)
        {
            throw new CustomException($"Cannot find class with the id : {classId}");
            return null;
        }
        existingClass.Name = updateClass.Name;
        await _context.SaveChangesAsync();
        return existingClass;
    }

    public async Task<Class> DeleteClass(int classId)
    {
        var existingClass = await _context.Classes.FindAsync(classId);
        if (existingClass == null)
        {
            throw new CustomException($"This class  is not found  with id :  {classId}");
            return null;
        }

        var userClasses = _context.UserClasses.Where(x => x.ClassId == classId);
        var assignments = _context.Assignments.Where(x => x.ClassId == classId);
        _context.Remove(userClasses);
        _context.Remove(assignments);
        await _context.SaveChangesAsync();
        return existingClass;
    }

    public async  Task<Class> GetClass(int classId)
    {
        return await _context.Classes.FindAsync(classId);
    }
    
    // lấy tất cả các lớp học sinh tham dự
    public async Task<List<Class>> GetALlByStudent(int studentId)
    {
        var queryable = from uc in _context.UserClasses
                        join c in _context.Classes on uc.ClassId equals c.ClassId
                        join u in _context.Users on uc.UserId equals u.Id
                        where uc.UserId == studentId && u.RoleId == 3
                        select c;
        var classAttends = await queryable.ToListAsync();
        // var queryable2 = from uc in _context.UserClasses
        //     where uc.UserId == studentId
        //     select uc.ClassId;
        //
        // var test = new List<Class>();
        // foreach (var classId in queryable2 )
        // {
        //     var classAttend = await _context.Classes.FindAsync(classId);
        //     test.Add(classAttend);
        // }
        return classAttends;
    }

    public async Task<List<Class>> GetAllByTeacher(int teacherId)
    {
        var queryable = from uc in _context.UserClasses
            join c in _context.Classes on uc.ClassId equals c.ClassId
            join u in _context.Users on uc.UserId equals u.Id
            where uc.UserId == teacherId && u.RoleId == 2
            select c;
        var classTeaching  = await queryable.ToListAsync();
        return classTeaching;
    }
}