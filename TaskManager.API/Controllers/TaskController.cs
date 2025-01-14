using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Data;

namespace TaskManager.API.Controllers
{
	[Route("task")]
	public class TaskController : Controller
	{
		private readonly DataContext _context;
        public TaskController(DataContext context)
        {
            _context = context;
        }
		[HttpGet]
        public IActionResult GetAllTasks()
		{
			var data = _context.Tasks.ToList(); 
			return Ok(data);
		}
		[HttpGet("{id}")]
		public IActionResult GetTaskByID([FromRoute] int id)
		{
			var data = _context.Tasks.FirstOrDefault(task => task.Id == id);
			return Ok(data);
		}
		[HttpPost]
		public IActionResult CreateTask([FromBody] Model.Task task)
		{
			_context.Tasks.Add(task);
			_context.SaveChanges();
			return CreatedAtAction(
				nameof(GetTaskByID), 
				new { id = task.Id }, task);
		}
		[HttpPut("{id}")]
		public IActionResult UpdateTask([FromRoute] int id, [FromBody] Model.Task task)
		{
			var data = _context.Tasks.FirstOrDefault(task => task.Id == id);

			if (data == null) {
				return NotFound("");
			}

			data.Title = task.Title;
			data.Status = task.Status;
			data.UpdatedAt = DateTime.Now;
			_context.SaveChanges();

			return Ok(task);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteTask([FromRoute] int id)
		{
			var data = _context.Tasks.FirstOrDefault(task => task.Id == id);

			if (data == null)
			{
				return NotFound("");
			}

			_context.Tasks.Remove(data);
			_context.SaveChanges();

			return NoContent();
		}
	}
}
