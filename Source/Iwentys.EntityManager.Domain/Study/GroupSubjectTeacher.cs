namespace Iwentys.EntityManager.Domain;

public class GroupSubjectTeacher
{
    public GroupSubjectTeacher(IwentysUser teacher, GroupSubject groupSubject, TeacherType teacherType)
    {
        Teacher = teacher;
        TeacherId = teacher.Id;
        GroupSubject = groupSubject;
        GroupSubjectId = groupSubject.Id;
        TeacherType = teacherType;
    }

    public int TeacherId { get; set; }
    public virtual IwentysUser Teacher { get; set; }

    public int GroupSubjectId { get; set; }
    public virtual GroupSubject GroupSubject { get; set; }

    public TeacherType TeacherType { get; set; }
}