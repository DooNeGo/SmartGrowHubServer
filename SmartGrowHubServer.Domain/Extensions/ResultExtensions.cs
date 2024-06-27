using LanguageExt.Common;

namespace SmartGrowHubServer.Domain.Extensions;

public static class ResultExtensions
{
    public static T ThrowIfFail<T>(this Result<T> result) =>
        result.IfFail(e => throw e);
}
