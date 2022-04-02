using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class GroupSubjectTeacherGenerator : IDbContextSeeder
{
    public GroupSubjectTeacherGenerator(
        TeacherGenerator teacherGenerator, SubjectGroupSubjectGenerator subjectGroupSubjectGenerator)
    {
        foreach (var groupSubject in subjectGroupSubjectGenerator.GroupSubjects)
        {
            var teacher = FakerSingleton.Instance.PickRandom(teacherGenerator.Teachers);
            groupSubject.AddPracticeTeacher(teacher.Teacher);
        }

        GroupSubjectTeachers = subjectGroupSubjectGenerator.GroupSubjects.SelectMany(g => g.Teachers).ToArray();
    }

    public GroupSubjectTeacher[] GroupSubjectTeachers { get; }

    public void Seed(IIwentysEntityManagerDbContext context)
    {
        context.GroupSubjectTeacher.AddRange(GroupSubjectTeachers);
    }
}