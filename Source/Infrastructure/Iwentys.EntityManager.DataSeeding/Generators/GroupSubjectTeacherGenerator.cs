﻿using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;
using Microsoft.EntityFrameworkCore;

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

    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupSubjectTeacher>().HasData(GroupSubjectTeachers);
    }
}