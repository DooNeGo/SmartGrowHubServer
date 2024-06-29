using SmartGrowHubServer.Domain.Model;
using SmartGrowHubServer.DTOs;
using SmartGrowHubServer.Requests;
using System.Text.Json.Serialization;

namespace SmartGrowHubServer.SerializerContext;

[JsonSerializable(typeof(UserDto))]
[JsonSerializable(typeof(User))]
[JsonSerializable(typeof(RegisterRequest))]
public sealed partial class SmartGrowHubSerializerContext
    : JsonSerializerContext;