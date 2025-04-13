using Celebra.Business.Dtos.BirthdayDtos;

namespace Celebra.Business.Services.Birthday;

public interface IBirthdayService
{
    Task CreateAsync(BirthdayCreateDto dto,string ip);
}
