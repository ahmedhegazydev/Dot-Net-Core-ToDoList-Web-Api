namespace MyApp.Persistence;

// src/Infrastructure/MyApp.Persistence/AppDbContext.cs
public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    public DbSet<Todo> Todos => Set<Todo>();
}
