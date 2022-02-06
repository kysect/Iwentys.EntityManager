using Iwentys.EntityManager.Domain.Entities.Teaching;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iwentys.EntityManager.DataAccess.Configurations.Teaching;

public class GroupSubjectTeacherConfiguration : IEntityTypeConfiguration<GroupSubjectTeacher>
{
    public void Configure(EntityTypeBuilder<GroupSubjectTeacher> builder)
    {
        builder.HasOne(s => s.Teacher);
        builder.HasOne(s => s.GroupSubject);
        builder.OwnsOne(s => s.TeacherType);
    }
}