using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public static class GetStudyGroupsByIdList
{
    public record Query(List<int> GroupIdList) : IRequest<Response>;
    public record Response(IReadOnlyCollection<StudyGroupProfileResponseDto> StudyGroups);

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
            var result = await _context
                .StudyGroups
                .ProjectTo<StudyGroupProfileResponseDto>(_mapper.ConfigurationProvider)
                .Where(g => request.GroupIdList.Contains(g.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}