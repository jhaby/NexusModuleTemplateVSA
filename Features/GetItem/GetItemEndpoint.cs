
namespace NexusModuleTemplate.Features.GetItem;

public class GetItemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/items/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetItemQuery(id);
            var result = await sender.Send(query);
            if(result.IsFailure)
            {
                return Results.NotFound(result.Error);
            }
            return Results.Ok(result.Value);
        });
    }
}
