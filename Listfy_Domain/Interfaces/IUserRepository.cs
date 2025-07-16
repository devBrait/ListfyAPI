using Listfy_Domain.DTOs;
using Listfy_Domain.Entities;

namespace Listfy_Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<UserDTO>> GetAllAsync();
    Task<UserDTO?> GetByEmailAsync(string email);
}