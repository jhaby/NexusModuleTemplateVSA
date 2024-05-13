namespace NexusModuleTemplate.Authentication;

public interface IExecutionContextAccessor
{
    string UserId { get; }

    Guid CorrelationId { get; }

    bool IsAvailable { get; }
}
