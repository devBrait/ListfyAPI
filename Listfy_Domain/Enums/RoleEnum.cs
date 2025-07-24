using System.Text.Json.Serialization;

namespace Listfy_Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))] 
public enum RoleEnum
{
    Admin = 0,
    User = 1,
}