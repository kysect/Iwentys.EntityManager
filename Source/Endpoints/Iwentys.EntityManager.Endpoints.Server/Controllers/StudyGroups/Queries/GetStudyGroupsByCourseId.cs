using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.Infrastructure.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Endpoints.Server;

public static class GetStudyGroupsByCourseId
{
    public record Query(int CourseId) : IRequest<Response>;
    public record Response(IReadOnlyCollection<StudyGroupProfileResponseDto> StudyGroups);

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IwentysEntityManagerDbContext _context;
        private readonly IMapper _mapper;

        public Handler(IwentysEntityManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            List<StudyGroupProfileResponseDto> result = await _context
                .StudyGroups
                .Where(gs => gs.StudyCourseId == request.CourseId)
                .ProjectTo<StudyGroupProfileResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}