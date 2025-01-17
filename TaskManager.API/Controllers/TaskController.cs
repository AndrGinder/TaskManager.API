using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		public async Task<IActionResult> GetAllTasks()
		{
			var data = await _context.Tasks.ToListAsync();
			return Ok(data);
		}
		[HttpGet(ApiRoutes.Task.GetById)]
		public async Task<IActionResult> GetTaskByID([FromRoute] int id)
		{
			var data = await _context.Tasks
				.FirstOrDefaultAsync(task => task.Id == id);
			return Ok(data);
		}
		[HttpPost(ApiRoutes.Task.Create)]
		public async Task<IActionResult> CreateTask([FromBody] TaskFormVM data)
		{
			var task = new Model.Task();
			task.Title = data.Title;
			task.Status = TaskStatus.NotCompleted;
			await _context.Tasks.AddAsync(task);
			await _context.SaveChangesAsync();
			return CreatedAtAction(
				nameof(GetTaskByID), 
				new { id = task.Id }, task);
		}
		[HttpPut(ApiRoutes.Task.Update)]
		public async Task<IActionResult> UpdateTask([FromRoute] int id, [FromBody] TaskUpdateVM data)
		{
			var task = await _context.Tasks
				.FirstOrDefaultAsync(task => task.Id == id);

			if (task == null) {
				return NotFound("");
			}

			task!.Title = data.Title;
			task.Status = data.Status;
			task.UpdatedAt = DateTime.UtcNow;
			await _context.SaveChangesAsync();

			return Ok(await _context.Tasks
				.FirstOrDefaultAsync(task => task.Id == id));
		}
		[HttpDelete(ApiRoutes.Task.Delete)]
		public async Task<IActionResult> DeleteTask([FromRoute] int id)
		{
			var data = await _context.Tasks
				.FirstOrDefaultAsync(task => task.Id == id);

			if (data == null)
			{
				return NotFound("");
			}

			_context.Tasks.Remove(data);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
