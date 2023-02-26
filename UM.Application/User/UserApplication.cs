using UM.Application.Contract.User;
using UM.Domain.UserAgg;

namespace UM.Application.User;

public class UserApplication : IUserApplication 
{
    private readonly IUserRepository _userRepository;
    
    public UserApplication(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        
    }

    public async Task<ulong> CreateUserAsync(CreateUserViewModel command)
    {
        var user = new Domain.UserAgg.User(command.Email, command.Password, command.FirstName, command.LastName);
        
        await _userRepository.AddUserAsync(user);
        return user.UserId;
    }

    public async Task UpdateUserAsync(UpdateUserViewModel command)
    {
        var user = new Domain.UserAgg.User(command.Email, command.Password, command.FirstName, command.LastName);
        _userRepository.UpdateUser(user);
    }

    public async Task GetUserByAsync(ulong id)
    {
        await _userRepository.GetUserByAsync(userId: id);
    }

    public async Task GetUserByAsync(string email)
    {
        await _userRepository.GetUserByAsync(email);
    }


    public async Task<FilterUserViewModel> FilterUserAsync(FilterUserViewModel command)
    {
        var query = _userRepository.GetUserQueryable();
        return command;
    }

} 