using SmartGrowHubServer.Domain.Common.Interfaces;
using SmartGrowHubServer.Domain.Extensions;

namespace SmartGrowHubServer.Domain.Common;

public readonly record struct UserName : IValueObject<UserName, string>
{
    private const int MinimumLength = 6;
    private const string Prefix = "UserName:";

    private static readonly UserName Default = (UserName)"EmptyUserName";

    private UserName(string str) => Value = str;

    public string Value { get; } = Default;

    public static implicit operator string(UserName userName) => userName.Value;
    public static explicit operator UserName(string value) => Create(value).ThrowIfFail();

    public static Fin<UserName> Create(string rawValue)
    {
        Fin<UserName> result =
            from nonEmpty in NonEmptyString.Create(rawValue.Trim())
            from latin in LatinString.Create(nonEmpty)
            from minLength in NonNegativeInteger.Create(MinimumLength)
            from bounded in BoundedString.Create(latin, minLength, None)
            select new UserName(bounded);

        return result.BiMap(
            Succ: x => x,
            Fail: error => error.AddPrefix(Prefix));
    }

    public override string ToString() => Value;
}