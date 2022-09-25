using System.Security.Claims;
using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Assignments;
using AssignmentApp.API.Repository.Classes;
using AssignmentApp.API.Repository.StudentAssignment;
using AssignmentApp.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentAssignmentController : Controller
{
    private readonly IStudentAssignmentRepository _studentAssignmentRepository;
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IClassRepository _classRepository;
    private readonly IMapper _mapper;

    public StudentAssignmentController(IStudentAssignmentRepository studentAssignmentRepository , IMapper mapper,IClassRepository classRepository, IAssignmentRepository assignmentRepository)
    {
        _studentAssignmentRepository = studentAssignmentRepository;
        _classRepository = classRepository;
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "3")]
    public async Task<IActionResult> GetAllAssignedAssignment()
    {
        var idClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var id = Int32.Parse(idClaim);
        var studentAssignments = await _studentAssignmentRepository.GetAllAssignedAssignment(id);
        var studentAssignmentsDto = _mapper.Map<List<StudentAssignmentDto>>(studentAssignments);
        return Ok(studentAssignmentsDto);
    }

    [HttpGet]
    [Route("Assignments/{AssignmentId:int}")]
    [Authorize(Roles = "2")]
    public async Task<IActionResult> GetAllStudentAssignmentForAssignment(int AssignmentId)
    {
        var assignment = await _assignmentRepository.GetAssignment(AssignmentId);
        var IdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var Id = Int32.Parse(IdClaim);
        var isUserInClass =  await _classRepository.IsUserInClass(assignment.ClassId, Id);
        if (!isUserInClass)
        {
            return BadRequest($"You cannot get student assignment to assignment  id {AssignmentId} because you not in class");
        }
        var studentAssignment = await _studentAssignmentRepository.GetAllStudentAssignmentForAssignment(AssignmentId);
        var studentAssignmentDto = _mapper.Map<List<StudentAssignmentDto>>(studentAssignment);
        return Ok(studentAssignmentDto);
    }

    [HttpPost]
    [Route("Assignments/{AssignmentId:int}/Student/{studentId:int}")]
    [Authorize(Roles = "2")]
    public async Task<IActionResult> GradeStudentAssignment(int AssignmentId, int studentId,
        AssignmentMarkCreateDto markCreateDto)
    {
        var assignment = await _assignmentRepository.GetAssignment(AssignmentId);
        var IdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var Id = Int32.Parse(IdClaim);
        var isUserInClass =  await _classRepository.IsUserInClass(assignment.ClassId, Id);
        if (!isUserInClass)
        {
            return BadRequest($"You cannot grade student assignment to assignment id {AssignmentId} because you not in class");
        }
        var studentAssignment = await _studentAssignmentRepository.GetStudentAssignment(AssignmentId, studentId);
        if (studentAssignment == null)
        {
            return NotFound();
        }
        
        studentAssignment = new StudentAssignment()
        {
            AssignmentId = studentAssignment.AssignmentId,
            StudentId = studentAssignment.StudentId,
            Submitted = studentAssignment.Submitted,
            SubmittedAt = studentAssignment.SubmittedAt,
            Grade = markCreateDto.Grade,
            Feedback = markCreateDto.Feedback
        };
        var response = await _studentAssignmentRepository.GradeAssignment(studentAssignment, AssignmentId, studentId);
        if (response == null)
        {
            return BadRequest($"student with id {studentId}  does not submit assignment with id {AssignmentId} or dont have assignment id {AssignmentId} assign to student {studentId}");
        }
        var studentAssignmentDto = _mapper.Map<StudentAssignmentDto>(response);
        return Ok(studentAssignmentDto);
    }
}