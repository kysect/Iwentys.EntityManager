using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetSubjectsByCourseId
{
    public record Query(int CourseId) : IRequest<Response>;

    public record Response(IReadOnlyCollection<SubjectDto> Subjects);

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
            List<SubjectDto> result = await _context
                .GroupSubjects
                .Where(gs => gs.StudyGroup.StudyCourseId == request.CourseId)
                .Select(gs => gs.Subject)
                .Distinct() 
                .ProjectTo<SubjectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}