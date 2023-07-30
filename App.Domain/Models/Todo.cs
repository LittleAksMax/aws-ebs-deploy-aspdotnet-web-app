using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.Models;

[Index(nameof(Title), IsUnique = true)] // add UNIQUE constraint to Title property
[PrimaryKey(nameof(TodoId))]
public sealed class Todo
{
    // TodoId not required since it can't necessarily be instantiated
    public Guid TodoId { get; init; }
    [Column(TypeName = "VARCHAR(100)")]
    public required string Title { get; set; }
    [Column(TypeName = "VARCHAR(500)")]
    public required string Description { get; set; }
}