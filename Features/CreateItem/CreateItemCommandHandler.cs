
namespace NexusModuleTemplate.Features.CreateItem;

internal class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Result<Guid>>
{
    private readonly AppDbContext _context;
    private readonly IValidator<CreateItemCommand> _validator;

    public CreateItemCommandHandler(AppDbContext context, IValidator<CreateItemCommand> validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Failure<Guid>(new Error(
                "Validation error",
                validationResult.ToString()));
        }
        var item = Item.Create(
                Guid.NewGuid(), request.Name, request.Description,
                request.Price, request.PictureUrl);
        await _context.Items.AddAsync(item, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(item.Id);
    }
}
