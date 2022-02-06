using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataSeeding;

public class StudentGenerator : IDbContextSeeder
{
    private const int StudentCount = 200;

    public StudentGenerator(StudyGroupGenerator studyGroupsGenerator, Faker<Student> studentFaker)
    {
        StudyGroup[] studyGroups = studyGroupsGenerator.StudyGroups;
        var students = studentFaker.Generate(StudentCount);

        foreach (var student in students)
        {
            var group = FakerSingleton.Instance.PickRandom(studyGroups);
            group.AddStudent(student);
        }

        foreach (var studyGroup in studyGroups)
        {
            var student = FakerSingleton.Instance.PickRandom(studyGroup.Students.ToArray());
            studyGroup.MakeAdmin(student);
        }

        var frediGroup = studyGroups.First(g => g.GroupName.Name.Contains("3505"));

        var fredi = new Student(
            228617,
            "Фреди",
            "Кисикович",
            "Катс",
            "FrediKats",
            DateTime.UtcNow,
            DateTime.UtcNow,
            new Faker().Image.PicsumUrl());

        frediGroup.AddStudent(fredi);
        students.Add(fredi);

        Students = students.ToArray();
    }

    public Student[] Students { get; set; }

    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(Students);
    }
}