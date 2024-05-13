
namespace NexusModuleTemplate.Events.IntegrationEvents;

internal class ItemAddedIntegrationEvent : IntegrationEvent
{
    public ItemAddedIntegrationEvent(Guid id, DateTime occurredOn, Guid itemId) : base(id, occurredOn)
    {
        ItemId = itemId;
    }

    public Guid ItemId { get; }
}
