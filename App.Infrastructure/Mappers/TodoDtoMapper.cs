using App.Domain.Dtos;
using App.Domain.Models;

namespace App.Infrastructure.Mappers;

public static class TodoDtoMapper
{
    public static TodoDto ToDto(this Todo domainEntity)
    {
        return new TodoDto
        {
            TodoId = domainEntity.TodoId,
            Description = domainEntity.Description,
            Title = domainEntity.Title
        };   
    }

    public static Todo ToDomainEntity(this TodoDto dto)
    {
        return new Todo
        {
            TodoId = dto.TodoId,
            Description = dto.Description,
            Title = dto.Title
        };
    }
}