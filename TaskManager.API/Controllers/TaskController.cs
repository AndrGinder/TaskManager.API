using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Data;
using TaskManager.API.ViewModel.Task;

namespace TaskManager.API.Controllers
{
	public class TaskController : Controller
	{
		private readonly DataContext _context;
		public TaskController(DataContext context)
		{
			_context = context;
		}
		[HttpGet(ApiRoutes.Task.GetAll)]
		public IActionResult GetAllTasks()
		{
			var data = _context.Tasks.ToList();
			return Ok(data);
		}
		[HttpGet(ApiRoutes.Task.GetById)]
		public IActionResult GetTaskByID([FromRoute] int id)
		{
			var data = _context.Tasks.FirstOrDefault(task => task.Id == id);
			return Ok(data);
		}
		[HttpPost(ApiRoutes.Task.Create)]
		public async Task<IActionResult> CreateTask([FromBody] TaskFormVM data)
		{
			var task = new Model.Task();
			task.Title = data.Title;
			await _context.Tasks.AddAsync(task);
			await _context.SaveChangesAsync();
			return CreatedAtAction(
				nameof(GetTaskByID), 
				new { id = task.Id }, task);
		}
		[HttpPut(ApiRoutes.Task.Update)]
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
		[HttpDelete(ApiRoutes.Task.Delete)]
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
