using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListWithAPI.Data;
using TodoListWithAPI.Models;

namespace TodoListWithAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/todo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _context.TodoItems.ToListAsync();
            return Ok(todos);
        }

        // POST: api/todo
        [HttpPost]
        public async Task<IActionResult> Create(TodoItem todo)
        {
            todo.CreatedAt = DateTime.Now;

            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);
        }
    }
}