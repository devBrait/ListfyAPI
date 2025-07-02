namespace Listfy_Domain.DTOs;

public class UserDTO
{
    public int id { get; set; }
    public string name { get; set; }
    public string user_name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
}