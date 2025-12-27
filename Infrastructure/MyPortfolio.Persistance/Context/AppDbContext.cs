using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Persistance.Context;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    public DbSet<WelcomeArea> WelcomeAreas { get; set; }
}
