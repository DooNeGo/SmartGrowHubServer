using Mediator;
using SmartGrowHubServer.ApplicationL.Commands.Users;
using Unit = LanguageExt.Unit;

namespace SmartGrowHubServer.Infrastructure.Data.Handlers.Commands;

internal sealed class CreateUserHandler(ApplicationContext context)
    : ICommandHandler<CreateUserCommand, Fin<Unit>>
{
    public ValueTask<Fin<Unit>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(FinSucc(unit));
    }
}
