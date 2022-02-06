using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public static class GetGroupSubjectByTeacherId
{
    public record Query(int? TeacherId) : IRequest<Response>;
    public record Response(List<GroupSubjectInfoDto> Groups);

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
            List<GroupSubjectInfoDto> result = await _context
                .GroupSubjects
                .WhereIf(request.TeacherId, gs => gs.Teachers
                    .Any(m => m.Teacher.Id == request.TeacherId))
                .ProjectTo<GroupSubjectInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}