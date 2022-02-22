using System.Linq.Expressions;

namespace Iwentys.EntityManager.Domain;

public class Subject
{
    private List<GroupSubject> _groupSubjects;

    public int Id { get; init; }
    public string Title { get; init; }

    public virtual IReadOnlyList<GroupSubject> GroupSubjects => _groupSubjects.AsReadOnly();

    public Subject(string title)
    {
        ArgumentNullException.ThrowIfNull(title);

        Title = title;
        _groupSubjects = new List<GroupSubject>();
    }

    public GroupSubject AddGroup(StudyGroup studyGroup, StudySemester studySemester, IwentysUser lecturer, IwentysUser practice)
    {
        ArgumentNullException.ThrowIfNull(studyGroup);
        ArgumentNullException.ThrowIfNull(lecturer);
        ArgumentNullException.ThrowIfNull(practice);
        
        var groupSubject = new GroupSubject(this, studyGroup, studySemester, lecturer);
        groupSubject.AddPracticeTeacher(practice);
        _groupSubjects.Add(groupSubject);
        return groupSubject;
    }

    public static Expression<Func<Subject, bool>> IsAllowedFor(int userId)
    {
        return s => s._groupSubjects.Any(gs => gs.Teachers.Any(pm=>pm.TeacherId == userId));
    }
}