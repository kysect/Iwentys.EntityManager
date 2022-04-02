using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application.Commands;

public static class SetGithubOrganization
{
    public record Command(int GroupSubjectId, string GithubOrganization) : IRequest;

    public class Handler : IRequestHandler<Command>
    {
        private readonly IIwentysEntityManagerDbContext _context;

        public Handler(IIwentysEntityManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var groupSubject = await _context.GroupSubjects.FirstAsync(gs => gs.Id == request.GroupSubjectId);

            groupSubject.UpdateGithubOrganization(new GithubOrganization(request.GithubOrganization));
            _context.GroupSubjects.Update(groupSubject);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}