using Microsoft.AspNetCore.Identity;

namespace MyPortfolio.Core.Entities;

public sealed class AppUser : IdentityUser<string>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
}
