using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudentProfilesByGithubUsernamesList
{
    public record Query(List<string> GithubUsernamesList) : IRequest<Response>;
    public record Response(IReadOnlyCollection<StudentDto> Students);

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
            List<StudentDto> result = await _context
                .Students
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .Where(s => request.GithubUsernamesList.Contains(s.GithubUsername))
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}