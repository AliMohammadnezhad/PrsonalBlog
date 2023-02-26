namespace UM.Application.Contract.User;

public interface IUserApplication
{
    Task<ulong> CreateUserAsync(CreateUserViewModel command);

    Task UpdateUserAsync(UpdateUserViewModel command);

    Task GetUserByAsync(ulong id);

    Task GetUserByAsync(string email);

    Task<FilterUserViewModel> FilterUserAsync(FilterUserViewModel command);
}