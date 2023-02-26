using System.Linq.Expressions;

namespace UM.Domain.UserAgg;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    void UpdateUser(User user);
    Task<User> GetUserByAsync(ulong userId);
    Task<User> GetUserByAsync(string email);
    IQueryable<User> GetUserQueryable();

    Task<bool> Exists(Expression<Func<User, bool>> expression);


    Task SaveChangesAsync();
}