namespace App.Domain.Dtos;

public sealed class TodoDto
{
    public required Guid TodoId { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}