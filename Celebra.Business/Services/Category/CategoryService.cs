using Celebra.Business.Dtos.CategoryDtos;
using Celebra.Core.Enums;
using Celebra.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Celebra.Business.Services.Category;

public class CategoryService(AppDbContext _context) : ICategoryService
{
    public async Task<List<CategoryGetAllDto>> GetAllAsync()
    {
        static string GetDisplayName(CategoryType categoryType)
        {
            var type = categoryType.GetType();
            var memInfo = type.GetMember(categoryType.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            return (attributes.Length > 0) ? ((DisplayAttribute)attributes[0]).Name : categoryType.ToString();
        }

        var categories = await _context.Categories.ToListAsync();

        var res = categories.Select(x => new CategoryGetAllDto
        {
            Id = x.Id,
            Name = GetDisplayName(x.Name)
        }).ToList();

        return res;
    }
}
