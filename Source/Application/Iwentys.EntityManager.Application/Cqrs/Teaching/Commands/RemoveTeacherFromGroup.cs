﻿using Iwentys.EntityManager.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public class RemoveTeacherFromGroup
{
    public record Command(int GroupSubjectId, int TeacherId) : IRequest;

    public class Handler : IRequestHandler<Command>
    {
        private readonly IIwentysEntityManagerDbContext _context;

        public Handler(IIwentysEntityManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var groupSubjectMentor = await _context.GroupSubjectTeacher.FirstOrDefaultAsync(gsm =>
                gsm.TeacherId == request.TeacherId
                && gsm.GroupSubjectId == request.GroupSubjectId,
                cancellationToken);

            if (groupSubjectMentor is null)
                throw new ArgumentException("User is not mentor", nameof(request));

            _context.GroupSubjectTeacher.Remove(groupSubjectMentor);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}