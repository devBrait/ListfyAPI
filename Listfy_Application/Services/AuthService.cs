using Listfy_Domain.DTOs;
using Listfy_Domain.Interfaces;

namespace Listfy_Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<string> LoginAsync(LoginDTO login)
    {
        var user = await _userRepository.GetByEmailAsync(login.email);  
        
        if(user is null || !BCrypt.Net.BCrypt.Verify(login.password, user.password))
            throw new Exception("Incorrect credentials");
        
        return _tokenService.GenerateToken(user);
    }
}