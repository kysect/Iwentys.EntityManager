using AutoMapper;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetSubjectById
{
    public record Query(int SubjectId) : IRequest<Response>;

    public record Response(SubjectDto? Subject);

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
            SubjectDto? result = await _mapper
                .ProjectTo<SubjectDto>(_context.Subjects)
                .FirstOrDefaultAsync(gs => gs.Id == request.SubjectId, cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}