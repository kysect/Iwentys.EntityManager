using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudentProfilesByStudentStatus
{
    public record Query(StudentStatusType StudentStatus) : IRequest<Response>;
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
            List<StudentDto> result = await _context.Students.
                Where(s => s.StudentStatus.Type == request.StudentStatus)
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}