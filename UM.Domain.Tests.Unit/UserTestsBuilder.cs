using UM.Domain.Services;
using UM.Domain.UserAgg;

namespace UM.Domain.Tests.Unit
{
    public class UserTestsBuilder
    {
        public string Email { get; private set; } = "Test@Gmail.com";
        public string Password { get; private set; } = "123456";
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        public UserTestsBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public UserTestsBuilder WithPassword(string password)
        {
            Password = password;
            return this;
        }

        public UserTestsBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public UserTestsBuilder WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public async Task<User> Build(IUserValidatorService validatorService)
        {
            return await User.CreateAsync(Email, Password, FirstName, LastName,validatorService);
        }

        public User Build()
        {
            return new User(Email, Password, FirstName, LastName);
        }

    }
}
