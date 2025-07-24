using Listfy_Domain.Enums;

namespace Listfy_Domain.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}