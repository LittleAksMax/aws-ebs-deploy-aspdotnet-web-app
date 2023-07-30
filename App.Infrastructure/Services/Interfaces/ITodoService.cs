using App.Domain.Dtos;

namespace App.Infrastructure.Services.Interfaces;

public interface ITodoService
{
    Task<List<TodoDto>> GetAllTodos();
    Task<TodoDto?> GetTodo(Guid id);
    Task<TodoDto?> Create(TodoDto dtoToCreate);
    Task<(TodoDto? Dto, bool Conflict)> Update(TodoDto dto);
    Task<bool> Delete(Guid id);
}