using NexusModuleTemplate.Contracts;
using NexusModuleTemplate.Entities.ValueObjects;

namespace NexusModuleTemplate.Features.CreateItem;

public sealed record CreateItemCommand(
    string Name,
    string Description,
    Amount Price,
    string PictureUrl) : IRequest<Result<Guid>>
{
}
