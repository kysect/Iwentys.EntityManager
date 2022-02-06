﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public static class GetStudentProfilesByCourseId
{
    public record Query(Guid CourseId) : IRequest<Response>;
    public record Response(IReadOnlyCollection<StudentInfoDto> Students);

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IwentysEntityManagerDatabaseContext _context;
        private readonly IMapper _mapper;

        public Handler(IwentysEntityManagerDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            List<StudentInfoDto> result = await _context
                .StudyGroups
                .Where(g => g.StudyCourse.Id == request.CourseId)
                .SelectMany(g => g.Students)
                .ProjectTo<StudentInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
            
            return new Response(result);
        }
    }
}