﻿using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;
using MediatR;

namespace Iwentys.EntityManager.Application;

public class GetTeachersByGroupSubjectId
{
    public record Query(int GroupSubjectId) : IRequest<Response>;
    public record Response(GroupTeachersResponseDto GroupTeachersResponse);

    public class Handler : IRequestHandler<Query,Response>
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
            GroupSubject groupSubject = await _context.GroupSubjects.GetById(request.GroupSubjectId);
                
            var groupMentorsDtos = _mapper.Map<GroupTeachersResponseDto>(groupSubject);

            return new Response(groupMentorsDtos);
        }
    }
}