using Iwentys.EntityManager.Domain.Entities.Study;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iwentys.EntityManager.DataAccess.Configurations.Study;

public class StudyGroupAdminConfiguration : IEntityTypeConfiguration<StudyGroupAdmin>
{
    public void Configure(EntityTypeBuilder<StudyGroupAdmin> builder)
    {
        builder.HasOne(a => a.Group);
        builder.HasOne(a => a.Admin);
    }
}