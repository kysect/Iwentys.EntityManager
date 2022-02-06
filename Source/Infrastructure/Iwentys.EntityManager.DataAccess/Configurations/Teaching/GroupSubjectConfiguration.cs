using Iwentys.EntityManager.Domain.Entities.Teaching;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iwentys.EntityManager.DataAccess.Configurations.Teaching;

public class GroupSubjectConfiguration : IEntityTypeConfiguration<GroupSubject>
{
    public void Configure(EntityTypeBuilder<GroupSubject> builder)
    {
        builder.HasOne(g => g.Subject);
        builder.HasOne(g => g.StudyGroup);
        builder.OwnsOne(g => g.StudySemester);
        builder.Navigation(g => g.Teachers).HasField("_groupSubjectTeachers");
    }
}