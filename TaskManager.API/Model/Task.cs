using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.API.Model
{
	[Table("task")]
	public class Task
	{
		[Key, Required]
		public int Id { get; set; }
		[Required] 
		public string Title { get; set; }
		public string Status { get; set; } = TaskStatus.NotCompleted;
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;
		public DateTime DeletedAt { get; set; }
	}
}
