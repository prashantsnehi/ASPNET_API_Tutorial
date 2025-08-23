using System;
using Microsoft.EntityFrameworkCore;
namespace API_Tutorial.Infrastructure
{
	public class APIDbContext : DbContext
	{
		public APIDbContext(DbContextOptions options) : base(options) 
		{
		}
	}
}

