using System.Security.Claims;
using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.StudentAssignment;
using AssignmentApp.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApp.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class StudentAssignmentController : Controller
{
    private readonly IStudentAssignmentRepository _studentAssignmentRepository;
    private readonly IMapper _mapper;

    public StudentAssignmentController(IStudentAssignmentRepository studentAssignmentRepository , IMapper mapper)
    {
        _studentAssignmentRepository = studentAssignmentRepository;
        _mapper = mapper;
    }

    [HttpGet]
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
    public async Task<IActionResult> GetAllStudentAssignmentOfAssignment(int AssignmentId)
    {
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
        return Ok(response);
    }
}