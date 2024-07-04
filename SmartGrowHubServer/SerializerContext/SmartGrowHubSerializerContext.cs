using SmartGrowHubServer.DTOs;
using SmartGrowHubServer.Requests;
using SmartGrowHubServer.Responses;
using System.Text.Json.Serialization;

namespace SmartGrowHubServer.SerializerContext;

[JsonSerializable(typeof(UserDto))]
[JsonSerializable(typeof(LoginResponse))]
[JsonSerializable(typeof(LoginRequest))]
[JsonSerializable(typeof(RegisterRequest))]
public sealed partial class SmartGrowHubSerializerContext
    : JsonSerializerContext;