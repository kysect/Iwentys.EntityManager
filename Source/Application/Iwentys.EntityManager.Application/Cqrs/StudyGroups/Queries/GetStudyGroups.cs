using AutoMapper;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudyGroups
{
    public record Query : IRequest<Response>;
    public record Response(IReadOnlyCollection<StudyGroupDto> StudyGroups);

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
            List<StudyGroupDto> result = await _mapper
                .ProjectTo<StudyGroupDto>(_context.StudyGroups)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}