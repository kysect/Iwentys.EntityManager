using Iwentys.EntityManager.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iwentys.EntityManager.DataAccess.Configurations;

public class AdminIwentysUserConfiguration : IEntityTypeConfiguration<AdminIwentysUser>
{
    public void Configure(EntityTypeBuilder<AdminIwentysUser> builder)
    {
        builder.HasOne(a => a.User);
    }
}