using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public class GetIwentysUserById
{
    public record Query(int StudentId) : IRequest<Response>;
    public record Response(IwentysUserDto? User);

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
            IwentysUserDto? result = await _mapper
                .ProjectTo<IwentysUserDto>(_context.IwentysUsers)
                .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}