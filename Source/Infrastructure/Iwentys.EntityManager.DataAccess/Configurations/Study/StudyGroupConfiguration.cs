using Iwentys.EntityManager.Domain.Entities.Study;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iwentys.EntityManager.DataAccess.Configurations.Study;

public class StudyGroupConfiguration : IEntityTypeConfiguration<StudyGroup>
{
    public void Configure(EntityTypeBuilder<StudyGroup> builder)
    {
        builder.OwnsOne(g => g.GroupName);
        builder.HasOne(g => g.StudyCourse);
        builder.Navigation(g => g.Students).HasField("_students");
        builder.Navigation(g => g.GroupSubjects).HasField("_groupSubjects");
        builder.HasOne<StudyGroupAdmin>("_studyGroupAdmin");
    }
}