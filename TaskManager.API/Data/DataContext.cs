using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskManager.API.Model;

namespace TaskManager.API.Data
{
	public class DataContext: IdentityDbContext<User>
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options) { }
		public DbSet<Model.Task> Tasks { get; set; }
	}
}
