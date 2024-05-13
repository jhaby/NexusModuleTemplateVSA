
using NexusModuleTemplate.Entities.ValueObjects;

namespace NexusModuleTemplate.Entities;

public class Item : BaseEntity
{
    private Item(Guid id, string name, string description, Amount price, string pictureUrl) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Amount Price { get; private set; } = Amount.Empty();
    public string PictureUrl { get; private set; }

    public static Item Create(Guid id, string name, string description, Amount price, string pictureUrl)
    {
        return new Item(id, name, description, price, pictureUrl);
    }

    public void Update(string name, string description, Amount price, string pictureUrl)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
    }
}
