using System.Text.RegularExpressions;
using UM.Domain.Exceptions;
using UM.Domain.Services;

namespace UM.Domain.UserAgg;

public class User
{
    public ulong UserId { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public bool IsActive { get; private set; } = false;
    public Guid ValidateKey { get; private set; }
    public DateTime CreateDate { get; private set; } = DateTime.Now;



    public User(string email, string password, string? firstName, string? lastName)
    {
      
        Guards(email, password);
        ValidateKey = ValidationKeyGenerator();
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }


    public static async Task<User> CreateAsync(string email, string password, string? firstName, string? lastName, IUserValidatorService? validatorService)
    {
        if (await validatorService.CheckUserEmailDuplicatedAsync(email))
        {
            throw new UserDuplicatedException();
        }

        return new User(email,password,firstName,lastName);
    }

    public void Update(  string? firstName, string? lastName)
    {
        ValidateKey = ValidationKeyGenerator();
        FirstName = firstName;
        LastName = lastName;
    }



    private static void Guards(string email, string password)
    {
        GuardAgainstNullEmail(email);
        GuardAgainstInvalidEmail(email);
        GuardAgainstInvalidPassword(password);
    }

    public void ChangeState(bool changed)
    {
        IsActive = changed;

    }

    private static void GuardAgainstInvalidPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new PasswordInvalidException();
    }

    private static void GuardAgainstNullEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new EmailInValidExceptions();
    }

    private static void GuardAgainstInvalidEmail(string email)
    {
        var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        if (!regex.IsMatch(email))
            throw new EmailInValidExceptions();

    }


    private static Guid ValidationKeyGenerator()
    {
        return Guid.NewGuid();
    }


    public void ChangePassword(string newPassword)
    {
        this.Password = newPassword;
    }

    public void VerifyEmail(Guid userValidateKey)
    {
        this.IsActive = true;
    }
}