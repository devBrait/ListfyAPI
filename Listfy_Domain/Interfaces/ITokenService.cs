using Listfy_Domain.DTOs;
using Listfy_Domain.Entities;

namespace Listfy_Domain.Interfaces;

public interface ITokenService
{
    string GenerateToken(UserDTO user);
}