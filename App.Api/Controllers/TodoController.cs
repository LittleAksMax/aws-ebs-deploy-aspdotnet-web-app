using App.Domain;
using App.Domain.Dtos;
using App.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiController]
public sealed class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService todoService)
    {
        _service = todoService;
    }
    
    [HttpGet(ApiRoutes.TodoRoutes.GetAllRoute)]
    [ApiVersion("1.0")]
    public async Task<IActionResult> GetAll()
    {
        List<TodoDto> todoDtos = await _service.GetAllTodos();
        return Ok(todoDtos);
    }
}