using AutoMapper;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public class GetStudyCourses
{
    public record Query : IRequest<Response>;
    public record Response(List<StudyCourseDto> Courses);

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
            List<StudyCourseDto> result = await _context
                .StudyCourses
                .Select(c => new StudyCourseDto(c.Id, c.StudyProgram.Name + " " + c.GraduationYear))
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}