namespace App.Domain.Models;

public sealed class Todo
{
    public required Guid TodoId { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}