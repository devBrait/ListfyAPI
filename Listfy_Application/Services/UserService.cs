using Listfy_Domain.DTOs;
using Listfy_Domain.Entities;
using Listfy_Domain.Interfaces;
using Listfy_Domain.Validators;

namespace Listfy_Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly SecurityService _securityService;
    private readonly UserDTOValidator _userDtoValidator;

    public UserService(IUserRepository userRepository, SecurityService securityService, UserDTOValidator userDtoValidator)
    {
        _userRepository = userRepository;   
        _securityService = securityService;
        _userDtoValidator = userDtoValidator;   
    }
    
    public async Task<UserDTO> CreateAsync(UserDTO user)
    {
        var result = await _userDtoValidator.ValidateAsync(user);
        if (!result.IsValid)
            throw new Exception(string.Join(" ",result.Errors.Select(e => e.ErrorMessage)));

        var userAlreadyExists = await _userRepository.GetByEmailAsync(user.email);
        if (userAlreadyExists != null)
            throw new Exception("An account with this email address already exists. Please use a different email.");
        
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

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        if(users == null)
            throw new Exception("Users not found");
        
        return users;
    }
}