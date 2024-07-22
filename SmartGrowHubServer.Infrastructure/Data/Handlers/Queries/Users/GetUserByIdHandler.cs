using Mediator;
using SmartGrowHubServer.ApplicationL.Queries.Users;
using SmartGrowHubServer.Domain.Model;

namespace SmartGrowHubServer.Infrastructure.Data.Handlers.Queries.Users;

internal sealed class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, TryOption<User>>
{
    public async ValueTask<TryOption<User>> Handle(GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        using var context = new ApplicationContext();

        return (await TryOptionAsync(async () =>
            Optional(await context.Users
                .FindAsync([query.Id.Value], cancellationToken)
                .ConfigureAwait(false))))
            .Bind(user => user
                .ToDomain()
                .ToTryOption());
    }
}
