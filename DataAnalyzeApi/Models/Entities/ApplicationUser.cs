using Microsoft.AspNetCore.Identity;

namespace DataAnalyzeApi.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;
}
