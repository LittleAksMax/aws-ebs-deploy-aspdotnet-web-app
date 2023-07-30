using App.DataAccess;
using App.Domain.Dtos;
using App.Domain.Models;
using App.Infrastructure.Mappers;
using App.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Services;

public sealed class TodoService : ServiceBase, ITodoService
{
    public TodoService(AppDbContext context) : base(context)
    {
    }

    public async Task<List<TodoDto>> GetAllTodos()
    {
        return await Context.Todos
            .Select(x => x.ToDto())
            .ToListAsync();
    }

    public async Task<TodoDto?> GetTodo(Guid id)
    {
        return (await FindById(id))?.ToDto();
    }

    public async Task<TodoDto?> Create(TodoDto dtoToCreate)
    {
        var todo = dtoToCreate.ToDomainEntity();
        var conflict = await Context.Todos
            .Where(x => x.Title == dtoToCreate.Title)
            .AnyAsync();

        if (conflict)
        {
            return null;
        }

        Context.Todos.Add(todo);
        await Context.SaveChangesAsync();
        
        return todo.ToDto(); // should be completed by the .Add query
    }

    public async Task<bool> Delete(Guid id)
    {
        var existingWithId = await FindById(id);
        
        // no object exists with the given GUID
        if (existingWithId is null)
        {
            return false;
        }
        
        Context.Todos.Remove(existingWithId);
        await Context.SaveChangesAsync();
        return true;
    }

    private async Task<Todo?> FindById(Guid id)
    {
        return await Context.Todos.Where(x => x.TodoId == id)
            .FirstOrDefaultAsync();
    }
}