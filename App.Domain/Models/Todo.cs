using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.Models;

[Index(nameof(Title), IsUnique = true)] // add UNIQUE constraint to Title property
public sealed class Todo
{
    public required Guid TodoId { get; init; }
    [Column(TypeName = "VARCHAR(100)")]
    public required string Title { get; init; }
    [Column(TypeName = "VARCHAR(500)")]
    public required string Description { get; init; }
}