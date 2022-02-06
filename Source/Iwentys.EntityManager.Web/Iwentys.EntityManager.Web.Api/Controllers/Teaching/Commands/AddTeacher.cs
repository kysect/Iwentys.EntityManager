using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain.Entities.Teaching;
using Iwentys.EntityManager.Domain.ValueObjects.Study;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public static class AddTeacher
{
    public record Command(SubjectTeacherCreateArgs Args) : IRequest;

    public class Handler : IRequestHandler<Command>
    {
        private readonly IwentysEntityManagerDatabaseContext _context;

        public Handler(IwentysEntityManagerDatabaseContext context)
        {
            _context = context;
        }

        // TODO: Decompose to AddMentor + AddPractice
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            List<GroupSubject> groupSubjects = await _context.GroupSubjects
                .Where(gs =>
                    gs.Subject.Id == request.Args.SubjectId
                    && request.Args.GroupSubjectIds.Contains(gs.StudyGroup.Id))
                .ToListAsync(cancellationToken);

            var teacher = await _context.Teachers.FindAsync(new object[] { request.Args.TeacherId }, cancellationToken);
            var type = TeacherType.Parse(request.Args.TeacherType);

            foreach (var groupSubject in groupSubjects)
            {
                groupSubject.AddTeacher(teacher, type);
                _context.GroupSubjects.Update(groupSubject);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}