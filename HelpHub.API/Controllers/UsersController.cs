using HelpHub.Application.DTOs;
using HelpHub.Application.Interfaces;
using HelpHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HelpHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _repository.GetAllAsync();

        var result = users.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        });

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return NotFound("User not found.");

        var result = new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email
        };

        var created = await _repository.CreateAsync(user);

        var result = new UserDto
        {
            Id = created.Id,
            Name = created.Name,
            Email = created.Email
        };

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserDto dto)
    {
        if (id != dto.Id)
            return BadRequest("Id in URL does not match Id in body.");

        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return NotFound("User not found.");

        user.Name = dto.Name;
        user.Email = dto.Email;

        await _repository.UpdateAsync(user);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);

        if (!deleted)
            return NotFound("User not found.");

        return NoContent();
    }
}