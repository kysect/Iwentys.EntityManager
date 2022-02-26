using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudyGroups
{
    public record Query : IRequest<Response>;
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
            List<StudyGroupDto> result = await _mapper
                .ProjectTo<StudyGroupDto>(_context.StudyGroups)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}