namespace TaskManager.API
{
	public static class ApiRoutes
	{
		public static class Task
		{
			public const string GetAll = "task";
			public const string GetById = "task/{id}";
			public const string Create = "task";
			public const string Update = "task/{id}";
			public const string Delete = "task/{id}";
		}
	}
}
