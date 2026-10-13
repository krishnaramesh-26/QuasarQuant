using Microsoft.EntityFrameworkCore;
using QuasarQuant.Core.Models;

namespace QuasarQuant.Repository.Data;

public class AppDbContext : DbContext
{

    // the :base(options) calls the parent's constructor with options argument passed in
    // that takes care of all the connection initialisation and stuff
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<TradeSignal> TradeSignals { get; set; } = null!;
    public DbSet<IdentityUser> IdentityUsers { get; set; } = null!;
    public DbSet<UserProfile> UserProfiles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TradeSignal>(entity =>
        {
            entity.Ignore(signal => signal.featureVector);
            entity.Ignore(signal => signal.probabilities);
            entity.Ignore(signal => signal.metadata);
        });

        modelBuilder.Entity<IdentityUser>(entity =>
        {
            entity.HasKey(user => user.uuid);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(profile => profile.uuid);
            entity.Property(profile => profile.uuid).ValueGeneratedNever();

            entity.HasOne(profile => profile.identityUser)
                .WithOne(user => user.profile)
                .HasForeignKey<UserProfile>(profile => profile.uuid)
                .IsRequired();
        });
    }
}