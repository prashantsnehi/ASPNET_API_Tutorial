using Microsoft.EntityFrameworkCore;
using API_Tutorial.Infrastructure.Entity;

namespace API_Tutorial.Infrastructure;
public class APIDbContext : DbContext
{
    public APIDbContext(DbContextOptions options) : base(options)
    {
    }

    #region Entity
    public virtual DbSet<User> Users { get; set; }
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}