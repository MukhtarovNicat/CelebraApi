using Celebra.Business.Dtos.CategoryDtos;

namespace Celebra.Business.Services.Category;

public interface ICategoryService
{
    Task<List<CategoryGetAllDto>> GetAllAsync();
}
