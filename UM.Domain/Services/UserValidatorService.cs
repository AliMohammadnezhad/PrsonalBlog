using UM.Domain.Exceptions;
using UM.Domain.UserAgg;

namespace UM.Domain.Services;

public class UserValidatorService:IUserValidatorService
{
    private readonly IUserRepository _repository;

    public UserValidatorService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CheckUserEmailDuplicatedAsync(string email)
    {
        return await _repository.Exists(x => x.Email.Equals(email));
    }
}