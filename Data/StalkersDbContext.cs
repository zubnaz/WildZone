using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace Data;
public class StalkersDbContext : IdentityDbContext<Stalker,IdentityRole<Guid>,Guid>
{
    public DbSet<Grouping> Grouping { get; set; }

    public DbSet<Rang> Rangs { get; set; }

    public DbSet<Avatar> Avatars { get; set; }

    public DbSet<EmailVerification> EmailVerifications { get; set; }

    public StalkersDbContext(DbContextOptions<StalkersDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Rang>()
            .HasMany(r => r.Stalkers)
            .WithOne(s => s.Rang)
            .HasForeignKey(s => s.RangId);

        builder.Entity<Grouping>()
            .HasMany(g => g.Members)
            .WithOne(s => s.Group)
            .HasForeignKey(s => s.GroupingId);

        builder.Entity<Grouping>()
            .HasOne(g => g.Leader);

        builder.Entity<Avatar>()
            .HasMany(a => a.Stalkers)
            .WithOne(s => s.Avatar)
            .HasForeignKey(s => s.AvatarId);

        builder.Entity<Avatar>()
           .HasOne(g => g.Group);



    }
}

