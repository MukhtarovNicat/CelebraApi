using Celebra.Business.Dtos.BirthdayDtos;
using Celebra.Business.Dtos.FileDtos;
using Celebra.Business.ExternalServices.FileService;
using Celebra.Business.Statics;
using Celebra.Core.Enums;
using Celebra.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Celebra.Business.Services.Birthday;
//TODO: Eger user RemindDate,RemindTime vermese default verilemlidir
public class BirthdayService(AppDbContext _context, IFileService _fileService) : IBirthdayService
{
    public async Task CreateAsync(BirthdayCreateDto dto, string ip)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Ip == ip);

        Core.Entities.Birthday birthday = new()
        {
            Name = dto.Name.Trim(),
            Surname = dto.Surname?.Trim(),
            BirthDate = dto.BirthDate,
            CategoryId = dto.CategoryId,
            RemindDate = (RemindDate)dto.RemindDate,
            RemindTime = (DateTime)dto.RemindTime,
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

    //==========================================PTIVATE==========================================
    public static ZodiacSign GetZodiacSign(DateTime date)
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
    public static ChineseZodiacSign GetChineseZodiacSign(DateTime date)
    {
        int baseYear = 2020; 
        int index = (date.Year - baseYear) % 12;
        if (index < 0) index += 12;

        return (ChineseZodiacSign)(index + 1);
    }

}
