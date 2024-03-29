﻿using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class AddTeacher
{
    public record Command(CreateSubjectTeacherRequestDto Args) : IRequest;

    public class Handler : IRequestHandler<Command>
    {
        private readonly IIwentysEntityManagerDbContext _context;

        public Handler(IIwentysEntityManagerDbContext context)
        {
            _context = context;
        }
                
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            List<GroupSubject> groupSubjects = await _context.GroupSubjects.Where(
                    gs => gs.SubjectId == request.Args.SubjectId
                          && request.Args.GroupSubjectIds.Contains(gs.StudyGroupId))
                .ToListAsync(cancellationToken);
                
            foreach (GroupSubject groupSubject in groupSubjects)
            {
                if (groupSubject.Teachers.Any(m => m.TeacherType == request.Args.TeacherType && m.TeacherId == request.Args.TeacherId))
                    continue;
                    
                // TODO: Add Teachers DbSet and invoke proper constructor
                // groupSubject.Teachers.Add(new GroupSubjectTeacher()
                // {
                //     TeacherType = request.Args.TeacherType,
                //     GroupSubjectId = groupSubject.Id,
                //     TeacherId = request.Args.TeacherId
                // });

                _context.GroupSubjects.Update(groupSubject);
            }

            await _context.SaveChangesAsync(cancellationToken);
                
            return Unit.Value;
        }
    }
}