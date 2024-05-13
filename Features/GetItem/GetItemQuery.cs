namespace NexusModuleTemplate.Features.GetItem;

public record GetItemQuery(Guid Id) : IRequest<Result<ItemResponse>>
{
    
}
