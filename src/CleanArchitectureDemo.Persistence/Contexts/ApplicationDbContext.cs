using CleanArchitectureDemo.Domain.Common;
using CleanArchitectureDemo.Domain.Common.Interfaces;
using CleanArchitectureDemo.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitectureDemo.Persistence.Contexts;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IDomainEventDispatcher _dispatcher;
    
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options, 
        IDomainEventDispatcher dispatcher
    ) : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Contact> Contacts => Set<Contact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (_dispatcher == null) return result;

        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
