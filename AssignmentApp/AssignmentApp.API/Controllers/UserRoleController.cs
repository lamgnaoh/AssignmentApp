﻿using AssignmentApp.API.DTOs;
using AssignmentApp.API.Repository.UserRoles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserRoleController:Controller
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public UserRoleController(IUserRoleRepository userRoleRepository,IMapper mapper)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUserRole(int userId)
    {
        var userRoles = await _userRoleRepository.GetALlRoleForUser(userId);
        var userRoleDto = _mapper.Map<List<UserRolesDto>>(userRoles);
        return Ok(userRoleDto);
    }
    [HttpPost]
    [Route("Users/{userId:int}/Roles/{roleId:int}")]
    public async Task<IActionResult> CreateUserRole(int userId,int roleId)
    {
        var userRoles = await _userRoleRepository.CreateUserRole(userId,roleId);
        var userRoleDto = _mapper.Map<List<UserRolesDto>>(userRoles);
        return Ok(userRoleDto);
    }
    [HttpDelete]
    [Route("Users/{userId:int}/Roles/{roleId:int}")]
    public async Task<IActionResult> DeleteRole(int userId,int roleId)
    {
        var userRoles = await _userRoleRepository.DeleteUserRole(userId,roleId);
        if (userRoles != null)
        {
            var userRoleDto = _mapper.Map<List<UserRolesDto>>(userRoles);
            return Ok(userRoleDto);
        }

        return BadRequest($"not found user id {userId} with role id {roleId}");
    }
    [HttpPut]
    [Route("Users/{userId:int}/Roles/{roleId:int}")]
    public async Task<IActionResult> UpdateUserRole(int userId,int roleId,roleUpdateRequest requestUpdate)
    {
        var userRoles = await _userRoleRepository.DeleteUserRole(userId,roleId);
        var newUserRoles = await _userRoleRepository.CreateUserRole(userId, requestUpdate.RoleId);
        var newUserRoleDto = _mapper.Map<List<UserRolesDto>>(newUserRoles);
        return Ok(newUserRoleDto);
    }
}