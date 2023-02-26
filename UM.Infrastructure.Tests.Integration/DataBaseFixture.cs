using System.Transactions;
using Microsoft.EntityFrameworkCore;
using UM.Domain.Tests.Unit;
using UM.Infrastructure.EFCore;

namespace UM.Infrastructure.Tests.Integration;

public class DataBaseFixture: IAsyncLifetime
{
    private readonly DbContextOptions<UserManagementDbContext> _options;
    private UserManagementDbContext _context;
    private readonly UserTestsBuilder _builder;

    public DataBaseFixture()
    {
        _options = new DbContextOptionsBuilder<UserManagementDbContext>()
            .UseSqlServer("Data Source=.;Initial Catalog=PersonalBlog; Integrated Security=True;TrustServerCertificate=True")
            .Options;

        _builder = new UserTestsBuilder();
    }



    public async Task InitializeAsync()
    {
        _context = new UserManagementDbContext(_options);

    }

    public async Task DisposeAsync()
    {
        _context.Users.RemoveRange(_context.Users);
        await _context.SaveChangesAsync();
        await _context.DisposeAsync();
    }

    public UserManagementDbContext GetContext()
    {
        return _context;
    }
}