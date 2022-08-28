using Bogus;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class SubjectGroupSubjectGenerator : IDbContextSeeder
{
    private const int SubjectCount = 3;
    private readonly StudySemester CurrentSemester = StudySemester.Y21H1;

    public SubjectGroupSubjectGenerator(
        Faker<Subject> subjectFaker, StudyGroupGenerator studyGroupGenerator, TeacherGenerator teacherGenerator)
    {
        Subjects = subjectFaker.Generate(SubjectCount).ToArray();
        var groupSubjects = new List<GroupSubject>();

        foreach (var studyGroup in studyGroupGenerator.StudyGroups)
        {
            var subject = FakerSingleton.Instance.PickRandom(Subjects);
            var lecturer = FakerSingleton.Instance.PickRandom(teacherGenerator.Teachers);
            var groupSubject = new GroupSubject(subject, studyGroup, CurrentSemester, lecturer.Teacher);
            groupSubjects.Add(groupSubject);
        }

        GroupSubjects = groupSubjects.ToArray();
    }

    public Subject[] Subjects { get; }
    public GroupSubject[] GroupSubjects { get; }

    public void Seed(IIwentysEntityManagerDbContext context)
    {
        context.Subjects.AddRange(Subjects);
        context.GroupSubjects.AddRange(GroupSubjects);
    }
}