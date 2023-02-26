using Microsoft.EntityFrameworkCore;
using UM.Domain.UserAgg;
using UM.Infrastructure.EFCore.Mapping;

namespace UM.Infrastructure.EFCore;

public class UserManagementDbContext : DbContext
{
    public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var assembly = typeof(UserMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);

    }
}