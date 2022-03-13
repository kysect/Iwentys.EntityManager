using AutoMapper;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetIwentysUsers
{
    public record Query : IRequest<Response>;
    public record Response(List<IwentysUserDto> Users);

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
            List<IwentysUserDto> result = await _mapper
                .ProjectTo<IwentysUserDto>(_context.IwentysUsers)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}