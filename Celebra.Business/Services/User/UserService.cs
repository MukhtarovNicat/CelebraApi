
using Celebra.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Celebra.Business.Services.User;

public class UserService(AppDbContext _dbContext) : IUserService
{
    public async Task CreateAsync(string ip)
    {
        bool checkExist = await _dbContext.Users.AnyAsync(x => x.Ip == ip);
        if (!checkExist)
        {
            Core.Entities.User user = new()
            {
                Ip = ip,
            };

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
