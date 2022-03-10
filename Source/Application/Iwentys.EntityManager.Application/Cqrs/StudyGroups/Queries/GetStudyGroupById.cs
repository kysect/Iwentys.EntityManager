using AutoMapper;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudyGroupById
{
    public record Query(int GroupId) : IRequest<Response>;

    public record Response(StudyGroupDto? StudyGroup);

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
            var result = await _mapper
                .ProjectTo<StudyGroupDto>(_context.StudyGroups)
                .SingleOrDefaultAsync(g => g.Id == request.GroupId, cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}