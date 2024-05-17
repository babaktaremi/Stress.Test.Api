using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTest.Api.Database.EntityModels;

namespace StressTest.Api.Database.Configuration;

public class UserEntityConfiguration:IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(c => c.UserId);
        builder.Property(c => c.FirstName).HasMaxLength(100).IsUnicode(true);
        builder.Property(c => c.FamilyName).HasMaxLength(100).IsUnicode(true);
        builder.Property(c => c.UserName).HasMaxLength(100).IsUnicode(true);

        builder.ToTable("Users", "usr");
    }
}