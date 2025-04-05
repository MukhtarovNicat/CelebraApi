using Celebra.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Celebra.DAL.Configurations;

public class BirthdayConfiguration : IEntityTypeConfiguration<Birthday>
{
    public void Configure(EntityTypeBuilder<Birthday> builder)
    {
        builder.HasOne(b => b.Category)
             .WithMany(c => c.Birthdays)
             .HasForeignKey(b => b.CategoryId)
             .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(b => b.User)
             .WithMany(c => c.Birthdays)
             .HasForeignKey(b => b.UserId)
             .OnDelete(DeleteBehavior.NoAction);
    }
}
