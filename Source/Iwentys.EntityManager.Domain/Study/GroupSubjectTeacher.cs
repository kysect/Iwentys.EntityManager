namespace Iwentys.EntityManager.Domain;

public class GroupSubjectTeacher
{
    public GroupSubjectTeacher(IwentysUser teacher, GroupSubject groupSubject, TeacherType teacherType) : this()
    {
        ArgumentNullException.ThrowIfNull(teacher);
        ArgumentNullException.ThrowIfNull(groupSubject);
        
        Teacher = teacher;
        TeacherId = teacher.Id;
        GroupSubject = groupSubject;
        GroupSubjectId = groupSubject.Id;
        TeacherType = teacherType;
    }

    private GroupSubjectTeacher(){}

    public int TeacherId { get; set; }
    public virtual IwentysUser Teacher { get; set; }

    public int GroupSubjectId { get; set; }
    public virtual GroupSubject GroupSubject { get; set; }

    public TeacherType TeacherType { get; set; }
}