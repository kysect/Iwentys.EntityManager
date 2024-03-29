﻿using Bogus;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class TeacherGenerator : IDbContextSeeder
{
    private const int TeacherCount = 10;

    public TeacherGenerator(Faker<GroupSubjectTeacher> teacherFaker)
    {
        Teachers = teacherFaker.Generate(TeacherCount).ToArray();
    }

    public GroupSubjectTeacher[] Teachers { get; }

    public void Seed(IIwentysEntityManagerDbContext context)
    {
        context.GroupSubjectTeacher.AddRange(Teachers);
    }
}