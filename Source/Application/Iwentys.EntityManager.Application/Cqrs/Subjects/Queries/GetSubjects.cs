using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetSubjects
{
    public record Query : IRequest<Response>;
    public record Response(IReadOnlyCollection<SubjectDto> Subjects);

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
            List<SubjectDto> result = await _mapper
                .ProjectTo<SubjectDto>(_context.Subjects)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}