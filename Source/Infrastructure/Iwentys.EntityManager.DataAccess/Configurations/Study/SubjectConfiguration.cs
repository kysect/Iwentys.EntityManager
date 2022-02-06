using Iwentys.EntityManager.Domain.Entities.Study;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iwentys.EntityManager.DataAccess.Configurations.Study;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.Navigation(s => s.GroupSubjects).HasField("_groupSubjects");
    }
}