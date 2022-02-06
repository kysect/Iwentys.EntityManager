using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.Entities.Teaching;
using Microsoft.EntityFrameworkCore;
using StudySemester = Iwentys.EntityManager.Domain.ValueObjects.Study.StudySemester;

namespace Iwentys.EntityManager.DataSeeding;

public class SubjectGroupSubjectGenerator : IDbContextSeeder
{
    private const int SubjectCount = 3;
    private readonly StudySemester CurrentSemester = StudySemester.H1;

    public SubjectGroupSubjectGenerator(
        Faker<Subject> subjectFaker, StudyGroupGenerator studyGroupGenerator, TeacherGenerator teacherGenerator)
    {
        Subjects = subjectFaker.Generate(SubjectCount).ToArray();
        var groupSubjects = new List<GroupSubject>();

        foreach (var studyGroup in studyGroupGenerator.StudyGroups)
        {
            var subject = FakerSingleton.Instance.PickRandom(Subjects);
            var lecturer = FakerSingleton.Instance.PickRandom(teacherGenerator.Teachers);
            var groupSubject = new GroupSubject(subject, CurrentSemester.Copy(), studyGroup, lecturer);
            groupSubjects.Add(groupSubject);
        }

        GroupSubjects = groupSubjects.ToArray();
    }

    public Subject[] Subjects { get; }
    public GroupSubject[] GroupSubjects { get; }

    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subject>().HasData(Subjects);
        modelBuilder.Entity<GroupSubject>().HasData(GroupSubjects);
    }
}