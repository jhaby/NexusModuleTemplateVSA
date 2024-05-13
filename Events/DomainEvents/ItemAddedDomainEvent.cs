
namespace NexusModuleTemplate.Events.DomainEvents;

internal record ItemAddedDomainEvent(Guid ItemId) : INotification;
