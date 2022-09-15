using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Assignments;
using AssignmentApp.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApp.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AssignmentController : Controller
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;

    public AssignmentController(IAssignmentRepository assignmentRepository , IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAssignment()
    {
        var assignments = await _assignmentRepository.GetAll();
        // var assignmentsDto = new List<AssignmentDto>();
        // assignments.ToList().ForEach(assignment =>
        // {
        //     var assignmentDto = new AssignmentDto()
        //     {
        //         Id = assignment.AssignmentId,
        //         ClassID = assignment.ClassId,
        //         Content = assignment.Content,
        //         CreateAt = assignment.CreateAt,
        //         DueTo = assignment.DueTo,
        //         Title = assignment.Title
        //     };
        //     assignmentsDto.Add(assignmentDto);
        // });
        var assignmentsDto = _mapper.Map<List<AssignmentDto>>(assignments);
        return Ok(assignmentsDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ActionName("GetAssignmentById")]
    public async Task<IActionResult> GetAssignmentById(int id)
    {
        var assignment = await _assignmentRepository.GetAssignment(id);
        if (assignment == null)
        {
            return NotFound();
        }
        var assignmentDto = _mapper.Map<AssignmentDto>(assignment);
        return Ok(assignmentDto);
    }

    [HttpGet]
    [Route("Class/{classId:int}")]
    public async Task<IActionResult> getAllAssigmentByClassId(int classId)
    {
        var assignments = await _assignmentRepository.GetAllByClass(classId);
        if (assignments == null)
        {
            return NotFound();
        }

        var assignmentDtos = new List<AssignmentDto>();
        foreach (var assignment in assignments)
        {
            var assignmentDto = _mapper.Map<AssignmentDto>(assignment);
            assignmentDtos.Add(assignmentDto);
        }
        return Ok(assignmentDtos);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAssignment(AssignmentCreateDto assignmentCreateDto)
    {
        // request dto to domain model
        var assignment = new Assignment()
        {
            ClassId = assignmentCreateDto.ClassId,
            CreateAt = assignmentCreateDto.CreateAt,
            DueTo = assignmentCreateDto.DueTo,
            Content = assignmentCreateDto.Content,
            Title = assignmentCreateDto.Title
        };
        // pass detail to repository
        var response = await _assignmentRepository.CreateAssignment(assignment);
        
        // convert back to dto
        var assignmentDto = new AssignmentDto()
        {
            Id = response.AssignmentId,
            ClassID = response.ClassId,
            CreateAt = response.CreateAt,
            DueTo = response.DueTo,
            Content = response.Content,
            Title = response.Title
        };
        return CreatedAtAction(nameof(GetAssignmentById), new { Id = response.AssignmentId }, assignmentDto);

    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteAssignment(int id)
    {
        //get assignment from database , if null  return not found 
        var assignment = await _assignmentRepository.DeleteAssignment(id);
        if (assignment == null)
        {
            return NotFound();
        }
        // convert response to Dto
        var assignmentDto = _mapper.Map<AssignmentDto>(assignment);
        return Ok(assignmentDto);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateAssignment([FromRoute]int id, [FromBody] AssignmentUpdateRequestDto assignmentUpdateRequestDto)
    {
        // convert dto to domain model 
        var updateAssignment = await _assignmentRepository.GetAssignment(id);
        if (updateAssignment == null)
        {
            return NotFound();
        }
        var classId = updateAssignment.ClassId;
        updateAssignment = new Assignment()
        {
            ClassId = classId,
            DueTo = assignmentUpdateRequestDto.DueTo,
            CreateAt = assignmentUpdateRequestDto.CreateAt,
            Content = assignmentUpdateRequestDto.Content,
            Title = assignmentUpdateRequestDto.Title
        };
        

        //update assignment using repository , if null then notfound
        var response = await _assignmentRepository.UpdateAssignment(updateAssignment, id);
        if (response == null)
        {
            return NotFound();
        }
        //convert domain model back to dto
        var assignmentDto = _mapper.Map<AssignmentDto>(response);
        //return ok response
        return Ok(assignmentDto);
    }

}