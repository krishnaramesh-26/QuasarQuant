using Microsoft.EntityFrameworkCore;
using QuasarQuant.Core.Models;

namespace QuasarQuant.Repository.Signals;

public class AppDbContext : DbContext
{

    // the :base(options) calls the parent's constructor with options argument passed in
    // that takes care of all the connection initialisation and stuff
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<TradeSignal> TradeSignals { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
    modelBuilder.Entity<TradeSignal>(entity =>
    {
        entity.Ignore(signal => signal.featureVector);
        entity.Ignore(signal => signal.probabilities);
        entity.Ignore(signal => signal.metadata);
    });
}
}