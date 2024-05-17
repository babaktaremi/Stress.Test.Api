using Microsoft.EntityFrameworkCore;
using StressTest.Api.Database.EntityModels;

namespace StressTest.Api.Database.DbContexts;

public class UserEntityDbContext:DbContext
{
    public UserEntityDbContext(DbContextOptions<UserEntityDbContext> options):base(options)
    {
        
    }

    public DbSet<UserEntity> Users => base.Set<UserEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}