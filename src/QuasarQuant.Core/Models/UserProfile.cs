namespace QuasarQuant.Core.Models;

public class UserProfile
{
    public Guid uuid { get; set; }
    public string displayName { get; set; } = string.Empty;
    public string timeZone { get; set; } = "UTC";
    public string preferredCurrency { get; set; } = "USD";
    public DateTime profileCreationTime { get; set; } = DateTime.UtcNow;
    public DateTime lastProfileUpdateTime { get; set; } = DateTime.UtcNow;
    
    public IdentityUser identityUser { get; set; } = null!;
}