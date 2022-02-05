using AutoMapper;
using Iwentys.EntityManager.Infrastructure.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Endpoints.Server;

public class GetIwentysUserById
{
    public record Query(int StudentId) : IRequest<Response>;
    public record Response(IwentysUserInfoDto User);

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
            IwentysUserInfoDto result = await _mapper
                .ProjectTo<IwentysUserInfoDto>(_context.IwentysUsers)
                .FirstAsync(s => s.Id == request.StudentId, cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}