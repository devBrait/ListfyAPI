using Listfy_Domain.DTOs;
using Listfy_Domain.Entities;
using Listfy_Domain.Interfaces;

namespace Listfy_Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly SecurityService _securityService;

    public UserService(IUserRepository userRepository, SecurityService securityService)
    {
        _userRepository = userRepository;   
        _securityService = securityService;
    }
    
    public async Task<UserDTO> CreateAsync(UserDTO user)
    {
        var hash = _securityService.HashPassword(user.password);
        
        var newUser = new User
        {
            name = user.name,
            user_name = user.user_name,
            email = user.email,
            password = hash,
            created_at = user.created_at
        };
        
        _userRepository.Add(newUser);
        await _userRepository.SaveAsync();

        return user;
    }
}