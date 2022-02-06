using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain.ValueObjects.Study;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public class GetUserTeacherTypeForSubject
{
    public record Query(int UserId, Guid SubjectId) : IRequest<Response>;
    public record Response(IReadOnlyCollection<string> TeacherType);

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IwentysEntityManagerDatabaseContext _context;

        public Handler(IwentysEntityManagerDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            List<TeacherType> teacherTypes = await _context
                .GroupSubjectTeachers
                .Where(gst => gst.GroupSubject.Subject.Id == request.SubjectId)
                .Where(gst => gst.Teacher.Id == request.UserId)
                .Select(gst => gst.TeacherType)
                .Distinct()
                .ToListAsync(cancellationToken: cancellationToken);
            
            return new Response(teacherTypes.Select(t => t.Value).ToArray());
        }
    }
}