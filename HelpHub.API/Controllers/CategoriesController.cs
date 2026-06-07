using HelpHub.Application.DTOs;
using HelpHub.Application.Interfaces;
using HelpHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HelpHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    public CategoriesController(ICategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _repository.GetAllAsync();

        var result = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        });

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            return NotFound("Category not found.");

        var result = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name
        };

        var created = await _repository.CreateAsync(category);

        var result = new CategoryDto
        {
            Id = created.Id,
            Name = created.Name
        };

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoryDto dto)
    {
        if (id != dto.Id)
            return BadRequest("Id in URL does not match Id in body.");

        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            return NotFound("Category not found.");

        category.Name = dto.Name;

        await _repository.UpdateAsync(category);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);

        if (!deleted)
            return NotFound("Category not found.");

        return NoContent();
    }
}