namespace NexusModuleTemplate.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }

    protected BaseEntity(Guid id)
    {
        Id = id;
    }
}
