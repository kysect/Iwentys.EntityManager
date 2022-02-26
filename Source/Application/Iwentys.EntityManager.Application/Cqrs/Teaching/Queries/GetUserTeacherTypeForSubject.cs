﻿using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public class GetUserTeacherTypeForSubject
{
    public record Query(int UserId, int SubjectId) : IRequest<Response>;
    public record Response(TeacherType TeacherType);

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IIwentysEntityManagerDbContext _context;

        public Handler(IIwentysEntityManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            List<TeacherType> teacherTypes = await _context
                .GroupSubjectTeacher
                .Where(gst => gst.GroupSubject.SubjectId == request.SubjectId)
                .Where(gst => gst.TeacherId == request.UserId)
                .Select(gst => gst.TeacherType)
                .Distinct()
                .ToListAsync(cancellationToken: cancellationToken);

            TeacherType aggregatedType = teacherTypes.Aggregate(TeacherType.None, (current, next) => current | next);

            return new Response(aggregatedType);
        }
    }
}