﻿using AutoMapper;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.Entities.Teaching;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;

namespace Iwentys.EntityManager.WebApi;

public class GetTeachersByGroupSubjectId
{
    public record Query(int GroupSubjectId) : IRequest<Response>;
    public record Response(GroupTeachersDto GroupTeachers);

    public class Handler : IRequestHandler<Query,Response>
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
            GroupSubject groupSubject = await _context.GroupSubjects.GetById(request.GroupSubjectId);
                
            var groupMentorsDtos = _mapper.Map<GroupTeachersDto>(groupSubject);

            return new Response(groupMentorsDtos);
        }
    }
}