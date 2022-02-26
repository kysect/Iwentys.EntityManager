using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudyGroupsByIdList
{
    public record Query(List<int> GroupIdList) : IRequest<Response>;
    public record Response(IReadOnlyCollection<StudyGroupDto> StudyGroups);

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
            var result = await _context
                .StudyGroups
                .ProjectTo<StudyGroupDto>(_mapper.ConfigurationProvider)
                .Where(g => request.GroupIdList.Contains(g.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}