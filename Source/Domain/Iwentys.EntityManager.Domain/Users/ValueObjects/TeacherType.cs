namespace Iwentys.EntityManager.Domain;

[Flags]
public enum TeacherType
{
    None = 0,
    Lecturer = 1,
    Practice = 2,
    Mentor = 4,
}