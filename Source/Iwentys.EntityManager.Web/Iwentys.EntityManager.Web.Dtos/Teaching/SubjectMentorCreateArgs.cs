using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.WebApiDtos;

public class CreateSubjectTeacherRequestDto
{
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public TeacherType TeacherType { get; set; }
    public IReadOnlyList<int> GroupSubjectIds { get; set; }
}