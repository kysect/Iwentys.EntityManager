using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetIwentysUsers
{
    public record Query : IRequest<Response>;
    public record Response(List<IwentysUserDto> Users);

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
            List<IwentysUserDto> result = await _mapper
                .ProjectTo<IwentysUserDto>(_context.IwentysUsers)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}