using Celebra.Business.Dtos.BirthdayDtos;
using Celebra.Core.Enums;

namespace Celebra.Business.Services.Birthday;

public interface IBirthdayService
{
    Task CreateAsync(BirthdayCreateDto dto, string ip);
    Task<ICollection<BirthdayGetAllDto>> GetAllAsync(string ip);
    Task<ICollection<BirthdayListGetAllByCategoryİdDto>> GetAllByCategoryAsync(CategoryType category, string ip);
}
