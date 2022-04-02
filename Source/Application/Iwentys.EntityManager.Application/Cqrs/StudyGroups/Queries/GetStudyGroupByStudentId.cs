using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application;

public static class GetStudyGroupByStudentId
{
    public record Query(int StudentId) : IRequest<Response>;
    public record Response(StudyGroupDto? StudyGroup);

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
            StudyGroupDto? result = await _context
                .Students
                .Where(sgm => sgm.Id == request.StudentId)
                .Select(sgm => sgm.Group)
                .ProjectTo<StudyGroupDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            return new Response(result);
        }
    }
}