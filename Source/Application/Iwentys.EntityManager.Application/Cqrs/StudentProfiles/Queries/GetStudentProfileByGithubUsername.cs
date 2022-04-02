using AutoMapper;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudentProfileByGithubUsername
{
    public record Query(string GithubUsername) : IRequest<Response>;
    public record Response(StudentDto? Student);

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
            StudentDto? result = await _mapper
                .ProjectTo<StudentDto>(_context.Students)
                .FirstOrDefaultAsync(s => s.GithubUsername == request.GithubUsername, cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}