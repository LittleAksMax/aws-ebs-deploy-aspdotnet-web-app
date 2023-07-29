using App.Domain.Dtos;

namespace App.Infrastructure.Services.Interfaces;

public interface ITodoService
{
    Task<List<TodoDto>> GetAllTodos();
}