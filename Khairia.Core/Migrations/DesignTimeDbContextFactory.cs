using Khairia.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Khairia.Core.Migrations
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
	{
		public CoreDbContext CreateDbContext(string[] args)
		{
			

			var builder = new DbContextOptionsBuilder<CoreDbContext>();


			builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=alkhair;Trusted_Connection=True;MultipleActiveResultSets=true");

			return new CoreDbContext(builder.Options);
		}
	}
}