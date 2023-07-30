using App.Contracts.Requests.Todo;
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
        var todoDtos = await _service.GetAllTodos();
        return Ok(todoDtos);
    }
    
    [HttpGet(ApiRoutes.TodoRoutes.GetRoute)]
    [ApiVersion("1.0")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var todoDto = await _service.GetTodo(id);
        return todoDto is not null ? Ok(todoDto) : NotFound();
    }

    [HttpPost(ApiRoutes.TodoRoutes.CreateRoute)]
    [ApiVersion("1.0")]
    public async Task<IActionResult> Create([FromBody] CreateTodoRequest body)
    {
        var todoDtoToCreate = new TodoDto
        {
            Title = body.Title,
            Description = body.Description
        };

        var resultDto = await _service.Create(todoDtoToCreate);

        return resultDto is not null
            ? Created(ApiRoutes.TodoRoutes.GetRoute.Replace("{id:guid}",
                    resultDto.TodoId.ToString()),
                resultDto)
            : Conflict();
    }

    [HttpPut(ApiRoutes.TodoRoutes.UpdateRoute)]
    [ApiVersion("1.0")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTodoRequest body)
    {
        var dtoToUpdate = new TodoDto
        {
            TodoId = id, Title = body.Title, Description = body.Description
        };
        var (resultDto, conflict) = await _service.Update(dtoToUpdate);
        if (resultDto is not null)
        {
            return Ok();
        }
        
        if (conflict)
        {
            return Conflict("Title must be unique.");
        }
        
        return NotFound();
    }

    [HttpDelete(ApiRoutes.TodoRoutes.DeleteRoute)]
    [ApiVersion("1.0")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var successfullyDeleted = await _service.Delete(id);
        return successfullyDeleted ? NoContent() : NotFound();
    }
}