using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudentProfilesByGithubUsernamesList
{
    public record Query(IReadOnlyList<string> GithubUsernamesList) : IRequest<Response>;
    public record Response(IReadOnlyCollection<StudentDto> Students);

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
            List<StudentDto> result = await _context
                .Students
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .Where(s => request.GithubUsernamesList.Contains(s.GithubUsername))
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}