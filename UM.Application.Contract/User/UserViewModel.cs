namespace UM.Application.Contract.User;

public class UserViewModel
{
    public ulong UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; } 
    public DateTime CreateDate { get; set; }
}