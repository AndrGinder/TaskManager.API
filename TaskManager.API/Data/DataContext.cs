using Microsoft.EntityFrameworkCore;

namespace TaskManager.API.Data
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options) { }
		public DbSet<Model.Task> Tasks { get; set; }
	}
}
