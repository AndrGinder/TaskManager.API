using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Data;

namespace TaskManager.API.Controllers
{
	public class TaskController : Controller
	{
		private readonly DataContext _dataContext;
        public TaskController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
		public IActionResult GetAll()
		{
			var data = _dataContext.Tasks.ToList();
			if (data == null)
			{
				return BadRequest();
			}
			return Ok(data);
		}
		[HttpPost]
		public IActionResult CreateNew([FromBody] Task task) {
			if (task == null) {
				return BadRequest();
			}
			_dataContext.Tasks.
	}
}
