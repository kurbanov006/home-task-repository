using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Project> Projects { get; set; }
}