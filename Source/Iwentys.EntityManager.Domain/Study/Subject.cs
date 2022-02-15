using System.Linq.Expressions;

namespace Iwentys.EntityManager.Domain;

public class Subject
{
    public int Id { get; init; }
    public string Title { get; init; }

    public virtual ICollection<GroupSubject> GroupSubjects { get; set; }

    public Subject(string title)
    {
        ArgumentNullException.ThrowIfNull(title);

        Title = title;
        GroupSubjects = new List<GroupSubject>();
    }

    public GroupSubject AddGroup(StudyGroup studyGroup, StudySemester studySemester, IwentysUser lecturer, IwentysUser practice)
    {
        ArgumentNullException.ThrowIfNull(studyGroup);
        ArgumentNullException.ThrowIfNull(lecturer);
        ArgumentNullException.ThrowIfNull(practice);
        
        var groupSubject = new GroupSubject(this, studyGroup, studySemester, lecturer);
        groupSubject.AddPracticeTeacher(practice);
        GroupSubjects.Add(groupSubject);
        return groupSubject;
    }

    public static Expression<Func<Subject, bool>> IsAllowedFor(int userId)
    {
        return s => s.GroupSubjects.Any(gs => gs.Teachers.Any(pm=>pm.TeacherId == userId));
    }
}