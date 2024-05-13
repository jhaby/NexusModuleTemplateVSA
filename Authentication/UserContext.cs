namespace NexusModuleTemplate.Authentication;

//Inherits from IUserContext for building blocks of the application
internal class UserContext
{
    private readonly IExecutionContextAccessor _executionContextAccessor;

    public UserContext(IExecutionContextAccessor executionContextAccessor)
    {
        _executionContextAccessor = executionContextAccessor;
    }

    public string UserId => _executionContextAccessor.UserId;
}
