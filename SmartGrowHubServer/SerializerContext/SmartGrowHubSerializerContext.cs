using SmartGrowHubServer.Domain.Model;
using System.Text.Json.Serialization;

namespace SmartGrowHubServer.SerializerContext;

[JsonSerializable(typeof(User))]
public sealed partial class SmartGrowHubSerializerContext
    : JsonSerializerContext;