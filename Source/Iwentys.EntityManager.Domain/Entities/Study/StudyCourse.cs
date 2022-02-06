using Iwentys.EntityManager.Domain.ValueObjects.Users;

namespace Iwentys.EntityManager.Domain.Entities.Study;

public class StudyCourse
{
    public StudyCourse(GraduationYear graduationYear, StudyProgram studyProgram)
    {
        Id = Guid.NewGuid();
        GraduationYear = graduationYear;
        StudyProgram = studyProgram;
    }

    protected StudyCourse() { }

    public Guid Id { get; protected init; }
    
    public virtual GraduationYear GraduationYear { get; protected init; }
    public virtual StudyProgram StudyProgram { get; protected init; }
}