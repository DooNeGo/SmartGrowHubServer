using LanguageExt;
using Mediator;
using SmartGrowHubServer.Domain.Common;
using SmartGrowHubServer.Domain.Model;

namespace SmartGrowHubServer.ApplicationL.Queries.Users;

public sealed record GetUserByIdQuery(Id<User> Id) : IQuery<TryOption<User>>;