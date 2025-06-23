using Listfy_Domain.Entities;
using Listfy_Domain.Interfaces;
using Listfy_Infrastructure.Context;

namespace Listfy_Infrastructure.Repositories;

public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository { }