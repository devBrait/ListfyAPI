using Listfy_Domain.DTOs;
using Listfy_Domain.Entities;
using Listfy_Domain.Interfaces;
using Listfy_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Listfy_Infrastructure.Repositories;

public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository
{
    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        return await _context.User
            .Select(user => new UserDTO
            {
                id = user.id,
                name = user.name,
                user_name = user.user_name,
                email = user.email,
                password = user.password,
                created_at = user.created_at,
                updated_at = user.updated_at,
            }).ToListAsync();
    }

    public async Task<UserDTO?> GetByEmailAsync(string email)
    {
        var user =  await _context.User.Where(user => user.email == email).FirstOrDefaultAsync();
        if (user == null) return null;

        var userDTO = new UserDTO
        {
            id = user.id,
            name = user.name,
            user_name = user.user_name,
            email = user.email,
            password = user.password,
            created_at = user.created_at,
            updated_at = user.updated_at,
        };
        
        return userDTO; 
    }
}