using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.Classes;
using AssignmentApp.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : Controller
{
    private readonly IClassRepository _classRepository;
    private readonly IMapper _mapper;

    public ClassController(IClassRepository classRepository , IMapper mapper)
    {
        _classRepository = classRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClass()
    {
        var classes = await _classRepository.GetAll();
        var classDto = _mapper.Map<List<ClassDto>>(classes);
        return Ok(classDto);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ActionName("GetClassById")]
    public async Task<IActionResult> GetClassById(int id)
    {
        var existingClass = await _classRepository.GetClass(id);
        if (existingClass == null)
        {
            return NotFound($"Cannnot find class with id : {id}");
            
        }

        var existingClassDto = _mapper.Map<ClassDto>(existingClass);
        return Ok(existingClassDto);
    }

    [HttpGet]
    [Route("student/{studentId:int}")]
    public async Task<IActionResult> GetAllByStudent(int studentId)
    {
        var classAttends = await _classRepository.GetALlByStudent(studentId);
        var classAttendsDto = _mapper.Map<List<ClassDto>>(classAttends);
        return Ok(classAttendsDto);
    }
    
    [HttpGet]
    [Route("teacher/{teacherId:int}")]
    public async Task<IActionResult> GetAllByTeacher(int teacherId)
    {
        var classTeaching = await _classRepository.GetAllByTeacher(teacherId);
        var classTeachingDto = _mapper.Map<List<ClassDto>>(classTeaching);
        return Ok(classTeachingDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClass(ClassCreateRequestDTO request)
    {
        var newClass = new Class()
        {
            Name = request.Name,
            CreateAt = DateTime.Now
        };
        var response = await _classRepository.CreateClass(newClass);
        var classDto = _mapper.Map<List<ClassDto>>(response);
        return CreatedAtAction(nameof(GetClassById), new { id = response.ClassId }, classDto);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteClass(int id)
    {
        //get assignment from database , if null  return not found 
        var deleteClass = await _classRepository.DeleteClass(id);
        if (deleteClass == null)
        {
            return NotFound();
        }
        // convert response to Dto
        var deleteClassDto = _mapper.Map<ClassDto>(deleteClass);
        return Ok(deleteClassDto);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateClass([FromRoute] int id,[FromBody] ClassUpdateRequestDto request)
    {
        var existingClass = await _classRepository.GetClass(id);
        if (existingClass == null)
        {
            return NotFound();
            
        }

        var classId = existingClass.ClassId;
        var createAt = existingClass.CreateAt;
        existingClass = new Class()
        {
            ClassId = classId,
            Name = request.Name,
            CreateAt = createAt
        };
        var updateClass = await _classRepository.UpdateClass(existingClass, id);
        if (updateClass == null)
        {
            return BadRequest();
        }

        var updateClassDto = _mapper.Map<ClassDto>(updateClass);
        return Ok(updateClassDto);
    }

    [HttpPost]
    [Route("{classId:int}/users/{userId:int}")]
    public async Task<IActionResult> AddUserToClass( int classId, int userId)
    {
        var userClass = await _classRepository.AddUserToClass(classId,userId);
        if (userClass == null)
        {
            return BadRequest($"Can not add user with id {userId} to class with id {classId}");
        }

        var userClassDto = _mapper.Map<UserClassDto>(userClass);
        return Ok(userClassDto);
    }
    
    [HttpDelete]
    [Route("{classId:int}/users/{userId:int}")]
    public async Task<IActionResult> RemoveUserToClass( int classId, int userId)
    {
        var userClass = await _classRepository.RemoveUserToClass(classId,userId);
        if (userClass == null)
        {
            return BadRequest($"Can not remove user with id {userId} to class with id {classId}");
        }
        return Ok();
    }

    [HttpGet]
    [Route("{classId:int}/users")]
    public async Task<IActionResult> GetAllUserInClass(int classId)
    {
        var users = await _classRepository.GetAllUserInClass(classId);
        var usersDto = _mapper.Map<List<UserDto>>(users);
        return Ok(usersDto);
    }
}