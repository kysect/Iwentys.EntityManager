using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain.ValueObjects.Study;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public static class GetSubjectsBySemester
{
    public record Query(string Semester) : IRequest<Response>;
    public record Response(IReadOnlyCollection<SubjectProfileDto> Subjects);
    
    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IwentysEntityManagerDatabaseContext _context;
        private readonly IMapper _mapper;

        public Handler(IwentysEntityManagerDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var semester = StudySemester.Parse(request.Semester);
            List<SubjectProfileDto> result = await _context
                .GroupSubjects
                .Where(gs => gs.StudySemester == semester)
                .Select(gs => gs.Subject)
                .Distinct()
                .ProjectTo<SubjectProfileDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }

}