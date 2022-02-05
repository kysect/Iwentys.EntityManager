﻿using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Infrastructure.DataAccess;
using Iwentys.EntityManager.WebApiDtos;

namespace Iwentys.EntityManager.Endpoints.Server;

public static class GroupSubjectExtensions
{
    public static IQueryable<Subject> SearchSubjects(this IQueryable<GroupSubject> query, SubjectSearchParametersDto searchParametersDto)
    {
        IQueryable<Subject> newQuery = query
            .WhereIf(searchParametersDto.StudentId, gs => gs.StudyGroup.Students.Any(s => s.Id == searchParametersDto.StudentId))
            .WhereIf(searchParametersDto.GroupId, gs => gs.StudyGroupId == searchParametersDto.GroupId)
            .WhereIf(searchParametersDto.StudySemester, gs => gs.StudySemester == searchParametersDto.StudySemester)
            .WhereIf(searchParametersDto.SubjectId, gs => gs.SubjectId == searchParametersDto.SubjectId)
            .WhereIf(searchParametersDto.CourseId, gs => gs.StudyGroup.StudyCourseId == searchParametersDto.CourseId)
            .Select(s => s.Subject)
            .Distinct();

        return newQuery;
    }
}