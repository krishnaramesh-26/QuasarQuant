

namespace QuasarQuant.Core.Models;

public class IdentityUser
{
    public string username {get; set;} = String.Empty;
    public Guid uuid {get; set;} = Guid.NewGuid();
    public string passwordHash {get; set;} = String.Empty;
    public string emailAddress {get; set;} = String.Empty;
    public bool emailConfirmationState {get; set;} = false; // True would mean email verified
    public bool accountLockoutState {get; set;} = false; // True is when account is locked
    public DateTime accountCreationTime {get; set;} = DateTime.UtcNow; // By Default, the account creation time is the current time in UTC
    public DateTime lastAccountUpdateTime {get; set;} = DateTime.UtcNow;

    public UserProfile? profile { get; set; }
}