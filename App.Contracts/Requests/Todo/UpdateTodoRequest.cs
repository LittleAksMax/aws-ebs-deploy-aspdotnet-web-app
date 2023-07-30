namespace App.Contracts.Requests.Todo;

public class UpdateTodoRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
}