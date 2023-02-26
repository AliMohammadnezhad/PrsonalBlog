using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UM.Domain.UserAgg;

namespace UM.Infrastructure.EFCore.Mapping;

public class UserMapping:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.UserId);

        builder.Property(user => user.Email).HasMaxLength(50).IsRequired();
        builder.Property(user => user.Password).HasMaxLength(40).IsRequired();
        builder.Property(user => user.FirstName).HasMaxLength(100).IsRequired(false);
        builder.Property(user => user.LastName).HasMaxLength(100).IsRequired(false);


    }
}