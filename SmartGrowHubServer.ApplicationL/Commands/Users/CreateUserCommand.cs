using LanguageExt;
using Mediator;
using SmartGrowHubServer.Domain.Model;
using Unit = LanguageExt.Unit;

namespace SmartGrowHubServer.ApplicationL.Commands.Users;

public sealed record CreateUserCommand(User User) : ICommand<Fin<Unit>>;