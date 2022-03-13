using AutoMapper;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetSubjectTeachers
{
    public record Query : IRequest<Response>;
    public record Response(IReadOnlyList<SubjectTeachersDto> Teachers);

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IIwentysEntityManagerDbContext _context;
        private readonly IMapper _mapper;

        public Handler(IIwentysEntityManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            List<GroupSubject> groupSubjects = await _context
                .GroupSubjects
                .ToListAsync(cancellationToken);

            var subjectMentorsDtos = _mapper.Map<List<SubjectTeachersDto>>(groupSubjects.GroupBy(x => x.SubjectId));
                
            return new Response(subjectMentorsDtos);
        }
    }
}