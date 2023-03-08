using Blogger.Extensions.Core.Domain.Abstractions.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Extensions.Mediator;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync<TContext>(this IMediatorHandler mediator,
        DbContextBase<TContext> ctx) where TContext : DbContext
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents) 
            mediator.PublishDomainEvent(domainEvent);


        var task = domainEvents
            .Select(async domainEvent => mediator.PublishDomainEvent(domainEvent));

        await Task.WhenAll(task);
    }
}