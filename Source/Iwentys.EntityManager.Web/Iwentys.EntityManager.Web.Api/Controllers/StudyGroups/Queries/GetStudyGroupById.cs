using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public static class GetStudyGroupById
{
    public record Query(int GroupId) : IRequest<Response>;
    public record Response(StudyGroupProfileResponseDto StudyGroup);

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
            var result = await _mapper
                .ProjectTo<StudyGroupProfileResponseDto>(_context.StudyGroups)
                .SingleOrDefaultAsync(g => g.Id == request.GroupId, cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}