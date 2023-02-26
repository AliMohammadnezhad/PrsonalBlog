using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UM.Domain.UserAgg;

namespace UM.Infrastructure.EFCore.Repositories;

public class UserRepository:IUserRepository
{
    private readonly UserManagementDbContext _context;

    public UserRepository(UserManagementDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public void UpdateUser(User user)
    {
        _context.Update(user);
    }

    public async Task<User> GetUserByAsync(ulong userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<User> GetUserByAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public IQueryable<User> GetUserQueryable()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Exists(Expression<Func<User, bool>> expression)
    {
        return await _context.Users.AnyAsync(expression);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}