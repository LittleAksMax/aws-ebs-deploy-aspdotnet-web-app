using App.DataAccess;
using App.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Controllers;

[ApiController]
public sealed class TodoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet(ApiRoutes.TodoRoutes.GetAllRoute)]
    [ApiVersion("1.0")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Todos.ToListAsync());
    }
}