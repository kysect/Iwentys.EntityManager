using Iwentys.EntityManager.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public class RemoveTeacherFromGroup
{
    public record Command(Guid GroupSubjectId, int TeacherId) : IRequest;

    public class Handler : IRequestHandler<Command>
    {
        private readonly IwentysEntityManagerDatabaseContext _context;

        public Handler(IwentysEntityManagerDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var groupSubjectMentor = await _context.GroupSubjectTeachers
                .FirstOrDefaultAsync(gsm =>
                        gsm.Teacher.Id == request.TeacherId && 
                        gsm.GroupSubject.Id == request.GroupSubjectId,
                    cancellationToken);

            if (groupSubjectMentor is null)
                throw new ArgumentException("User is not mentor", nameof(request));

            _context.GroupSubjectTeachers.Remove(groupSubjectMentor);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}