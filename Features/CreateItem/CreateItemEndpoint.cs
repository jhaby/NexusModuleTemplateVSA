
using Mapster;

namespace NexusModuleTemplate.Features.CreateItem;

public class CreateItemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/items", async (CreateItemRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateItemCommand>();
            var result = await sender.Send(command);
            if(result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }
            return Results.Ok(result.Value);
        });
    }
}
