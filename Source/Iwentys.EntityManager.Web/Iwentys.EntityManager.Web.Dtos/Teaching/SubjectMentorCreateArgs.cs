namespace Iwentys.EntityManager.WebApiDtos;

public class SubjectTeacherCreateArgs
{
    public Guid SubjectId { get; set; }
    public int TeacherId { get; set; }
    public string TeacherType { get; set; }
    public IReadOnlyList<Guid> GroupSubjectIds { get; set; }
}