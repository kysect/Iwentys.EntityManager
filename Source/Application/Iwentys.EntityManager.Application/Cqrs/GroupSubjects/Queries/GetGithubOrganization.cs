using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public class GetGithubOrganization
{
    public record Query(int? GithubOrganizationId) : IRequest<Response>;
    public record Response(GithubOrganization? GithubOrganization);

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
            GithubOrganization? result = await _context
                .GithubOrganizations
                .FirstOrDefaultAsync(x => x.Id == request.GithubOrganizationId, cancellationToken);

            return new Response(result);
        }
    }
}