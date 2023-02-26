using UM.Domain.UserAgg;

namespace UM.Domain.Services;

public interface IUserValidatorService
{
    Task<bool> CheckUserEmailDuplicatedAsync(string email);
}