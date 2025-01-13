using Microsoft.EntityFrameworkCore;
using TaskManager.API.Model;

namespace TaskManager.API.Data
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<GuestTask> Tasks { get; set; }
	}
}
