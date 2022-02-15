namespace Iwentys.EntityManager.Domain;

public class StudyCourse
{
    public StudyCourse(StudentGraduationYear graduationYear, StudyProgram studyProgram)
    {
        ArgumentNullException.ThrowIfNull(studyProgram);
        
        GraduationYear = graduationYear;
        StudyProgram = studyProgram;
        StudyProgramId = studyProgram.Id;
    }

    public int Id { get; init; }
    public virtual StudentGraduationYear GraduationYear { get; init; }

    public int StudyProgramId { get; init; }
    public virtual StudyProgram StudyProgram { get; init; }
}