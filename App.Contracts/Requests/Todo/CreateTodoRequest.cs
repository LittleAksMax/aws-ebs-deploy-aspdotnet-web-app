namespace App.Contracts.Requests.Todo;

public sealed class CreateTodoRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
}