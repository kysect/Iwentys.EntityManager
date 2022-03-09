using AutoMapper;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public class GetGithubOrganization
{
    public record Query(int? GithubOrganizationId) : IRequest<Response>;
    public record Response(GithubOrganizationDto? GithubOrganization);

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
            var result = await _mapper
                .ProjectTo<GithubOrganizationDto>(_context.GithubOrganizations)
                .SingleOrDefaultAsync(x => x.Id == request.GithubOrganizationId, cancellationToken);

            return new Response(result);
        }
    }
}