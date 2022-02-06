using Iwentys.EntityManager.Domain.Entities.Study;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iwentys.EntityManager.DataAccess.Configurations.Study;

public class StudyCourseConfiguration : IEntityTypeConfiguration<StudyCourse>
{
    public void Configure(EntityTypeBuilder<StudyCourse> builder)
    {
        builder.OwnsOne(s => s.GraduationYear);
        builder.HasOne(s => s.StudyProgram);
    }
}