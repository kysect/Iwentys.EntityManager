﻿using AutoMapper;
using Iwentys.EntityManager.Infrastructure.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Endpoints.Server;

public static class GetSubjectById
{
    public record Query(int SubjectId) : IRequest<Response>;
    public record Response(SubjectProfileDto Subject);

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
            SubjectProfileDto result = await _mapper
                .ProjectTo<SubjectProfileDto>(_context.Subjects)
                .FirstOrDefaultAsync(s => s.Id == request.SubjectId, cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}