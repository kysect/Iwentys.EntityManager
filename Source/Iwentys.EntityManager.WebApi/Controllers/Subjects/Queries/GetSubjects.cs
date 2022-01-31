using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public class GetSubjects
{
    public class Query : IRequest<Response> { }

    public class Response
    {
        public Response(List<SubjectProfileDto> subjects)
        {
            Subjects = subjects;
        }

        public List<SubjectProfileDto> Subjects { get; set; }
    }

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
            List<SubjectProfileDto> result = await _mapper
                .ProjectTo<SubjectProfileDto>(_context.Subjects)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}