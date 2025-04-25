using Celebra.Business.Dtos.BirthdayDtos;
using Celebra.Business.Dtos.FileDtos;
using Celebra.Business.Exceptions.Common;
using Celebra.Business.ExternalServices.FileService;
using Celebra.Business.Statics;
using Celebra.Core.Enums;
using Celebra.DAL.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Celebra.Business.Services.Birthday;
public class BirthdayService : IBirthdayService
{
    private readonly AppDbContext _context;
    private readonly IFileService _fileService;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly string _baseUrl;

    public BirthdayService(AppDbContext context, IFileService fileService, IHttpContextAccessor contextAccessor)
    {
        _context = context;
        _fileService = fileService;
        _contextAccessor = contextAccessor;

        var request = contextAccessor.HttpContext?.Request;
        _baseUrl = $"{request?.Scheme}://{request?.Host.Value}{request?.PathBase.Value}";
    }
    public async Task CreateAsync(BirthdayCreateDto dto, string ip)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Ip == ip);

        var defaultRemindDate = RemindDate.OnSameDay;
        var defaultRemindTime = new DateTime(1, 1, 1, 9, 0, 0);

        Core.Entities.Birthday birthday = new()
        {
            Name = dto.Name.Trim(),
            Surname = dto.Surname?.Trim(),
            BirthDate = dto.BirthDate,
            CategoryId = dto.CategoryId,
            RemindDate = dto.RemindDate ?? defaultRemindDate,
            RemindTime = dto.RemindTime ?? defaultRemindTime,
            UserId = user.Id,
            ZodiacSign = GetZodiacSign(dto.BirthDate),
            ChineseZodiacSign = GetChineseZodiacSign(dto.BirthDate)
        };

        if (dto.Image != null)
        {
            FileDto? image = await _fileService.UploadAsync(RootConstants.BirthdayImage, dto.Image);
            birthday.Image = $"{image.FilePath}/{image.FileName}";
        }

        await _context.Birthdays.AddAsync(birthday);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<BirthdayGetAllDto>> GetAllAsync(string ip)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Ip == ip)
            ?? throw new NotFoundException<Core.Entities.Birthday>();

        var birthdays = await _context.Birthdays
            .Select(b => new BirthdayGetAllDto
            {
                Id = b.Id,
                FullName = $"{b.Name} {b.Surname}",
                Image = $"{_baseUrl}/{b.Image}",
                BirthDate = b.BirthDate,
                ZodiacSign = b.ZodiacSign,
                ChineseZodiacSign = b.ChineseZodiacSign,
            })
            .ToListAsync();

        return birthdays;
    }

    public async Task<ICollection<BirthdayListGetAllByCategoryİdDto>> GetAllByCategoryAsync(CategoryType category, string ip)
    {
        var query = _context.Birthdays.Include(x => x.Category).Where(x => x.User.Ip == ip).AsQueryable();
        if(category != CategoryType.All)
        {
            query = query.Where(x => x.Category.Name == category);
        }
        var res = await query.Select(x => new BirthdayListGetAllByCategoryİdDto
        {
            Id = x.Id,
            Name = x.Name,
            Surname = x.Surname,
            RemindTime = x.RemindTime,
            BirthDate = x.BirthDate
        }).ToListAsync();

        return res;
    }

    //==========================================PTIVATE==========================================
    private static ZodiacSign GetZodiacSign(DateTime date)
    {
        int day = date.Day;
        int month = date.Month;

        return (month, day) switch
        {
            (3, >= 21) or (4, <= 19) => ZodiacSign.Aries,
            (4, >= 20) or (5, <= 20) => ZodiacSign.Taurus,
            (5, >= 21) or (6, <= 20) => ZodiacSign.Gemini,
            (6, >= 21) or (7, <= 22) => ZodiacSign.Cancer,
            (7, >= 23) or (8, <= 22) => ZodiacSign.Leo,
            (8, >= 23) or (9, <= 22) => ZodiacSign.Virgo,
            (9, >= 23) or (10, <= 22) => ZodiacSign.Libra,
            (10, >= 23) or (11, <= 21) => ZodiacSign.Scorpio,
            (11, >= 22) or (12, <= 21) => ZodiacSign.Sagittarius,
            (12, >= 22) or (1, <= 19) => ZodiacSign.Capricorn,
            (1, >= 20) or (2, <= 18) => ZodiacSign.Aquarius,
            (2, >= 19) or (3, <= 20) => ZodiacSign.Pisces,
            _ => throw new Exception("Invalid date")
        };
    }
    private static ChineseZodiacSign GetChineseZodiacSign(DateTime date)
    {
        int baseYear = 2020;
        int index = (date.Year - baseYear) % 12;
        if (index < 0) index += 12;

        return (ChineseZodiacSign)(index + 1);
    }
}
