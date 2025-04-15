namespace Celebra.Business.Services.User;

public interface IUserService
{
    Task CreateAsync(string ip);
}
