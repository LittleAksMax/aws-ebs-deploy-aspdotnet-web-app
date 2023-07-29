namespace App.Domain.Dtos;

public sealed class TodoDto
{
    // not required since it is created automatically
    public Guid TodoId { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}