using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudentProfileByGithubUsername
{
    public record Query(string GithubUsername) : IRequest<Response>;
    public record Response(StudentDto? Student);

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
            StudentDto? result = await _mapper
                .ProjectTo<StudentDto>(_context.Students)
                .FirstOrDefaultAsync(s => s.GithubUsername == request.GithubUsername, cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}