using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Entities;

namespace MyPortfolio.Persistance.Context;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    public DbSet<WelcomeArea> WelcomeAreas { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>()
            .HasOne(i => i.About)
            .WithOne(a => a.Image)
            .HasForeignKey<Image>(i => i.AboutId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Image>()
            .HasIndex(i => i.AboutId)
            .IsUnique();

        modelBuilder.Entity<Image>()
            .HasOne(i => i.WelcomeArea)
            .WithOne(a => a.Image)
            .HasForeignKey<Image>(i => i.WelcomeAreaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Image>()
            .HasIndex(i => i.WelcomeAreaId)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
