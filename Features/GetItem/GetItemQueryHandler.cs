
namespace NexusModuleTemplate.Features.GetItem;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, Result<ItemResponse>>
{
    private readonly AppDbContext _dbContext;

    public GetItemQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<ItemResponse>> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var itemResponse = await _dbContext.Items
            .Include(i => i.Price)
            .Where(i => i.Id == request.Id)
            .Select(i => new ItemResponse
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                PictureUrl = i.PictureUrl,
                Price = i.Price
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (itemResponse is null)
        {
            return Result.Failure<ItemResponse>(new Error(
                "Item.NotFound",
                "Item not found"));
        }

        return Result.Success(itemResponse);
    }
}
