using System.Net.Sockets;
using AssignmentApp.Data.Entities;

namespace AssignmentApp.API.Repository.Classes;

public interface IClassRepository
{
    Task<List<Class>> GetAll();
    Task<Class> CreateClass(Class createClass);
    Task<Class> UpdateClass(Class updateClass , int classId);
    Task<Class> DeleteClass(int classId);
    Task<Class> GetClass(int classId);
    Task<List<Class>> GetALlByStudent(int studentId);
    Task<List<Class>> GetAllByTeacher(int teacherId);
}