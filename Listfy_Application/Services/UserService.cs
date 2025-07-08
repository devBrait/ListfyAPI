using Listfy_Domain.DTOs;
using Listfy_Domain.Entities;
using Listfy_Domain.Interfaces;
using Listfy_Domain.Validators;

namespace Listfy_Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly SecurityService _securityService;
    private readonly UserDTOValidator _userDTOValidator;

    public UserService(IUserRepository userRepository, SecurityService securityService, UserDTOValidator userDTOValidator)
    {
        _userRepository = userRepository;   
        _securityService = securityService;
        _userDTOValidator = userDTOValidator;   
    }
    
    public async Task<UserDTO> CreateAsync(UserDTO user)
    {
        var result = await _userDTOValidator.ValidateAsync(user);
        
        if (!result.IsValid)
            throw new Exception(string.Join(" ",result.Errors.Select(e => e.ErrorMessage)));
        
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