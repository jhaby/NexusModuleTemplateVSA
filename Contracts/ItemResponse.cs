using NexusModuleTemplate.Entities.ValueObjects;

namespace NexusModuleTemplate.Contracts;

public sealed record ItemResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Amount Price { get;  set; } = Amount.Empty();
    public string PictureUrl { get; set; } = string.Empty;
}
