using AutoMapper;
using AutoMapper.QueryableExtensions;
using FuzzySharp;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.WebApi;

public class GetStudentsByCredentials
{
    public record Query(string UserCredentials) : IRequest<Response>;

    public record Response(List<StudentInfoDto> Students);

    public class Handler : IRequestHandler<Query, Response>
    {
        private static readonly int MinimumMatchPercent = 100;
        private readonly IwentysEntityManagerDbContext _context;
        private readonly IMapper _mapper;

        public Handler(IwentysEntityManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var credentials = request.UserCredentials.Trim();
            var credentialsAmount = credentials.Split(' ').Length;

            // Fuzz couldn't work with await, so I firstly get full students list and then filter it
            List<StudentInfoDto> result = await _context
                .Students
                .ProjectTo<StudentInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            var filteredResult = result
                .Where(s =>
                    CredentialsMatchPercentSum(credentials, s) >= credentialsAmount * MinimumMatchPercent)
                .OrderByDescending(s =>
                    OneCredentialMatchPercent(credentials, s.FirstName) >= MinimumMatchPercent &&
                    OneCredentialMatchPercent(credentials, s.SecondName) >= MinimumMatchPercent)
                .ThenByDescending(s =>
                    CredentialsMatchPercentSum(credentials, s))
                .ToList();

            // Dict with (student, CredentialsMatchPercents) for debug and to ensure if it works properly
            // var debugDictionary = filteredResult.ToDictionary(
            //     s => $"{s.FirstName} {s.MiddleName} {s.SecondName}",
            //     matchSum => new
            //     {
            //         FirstNameMatch = OneCredentialMatchPercent(credentials, matchSum.FirstName),
            //         MiddleNameMatch = OneCredentialMatchPercent(credentials, matchSum.MiddleName),
            //         SecondNameMatch = OneCredentialMatchPercent(credentials, matchSum.SecondName),
            //         MatchSum = CredentialsMatchPercentSum(credentials, matchSum),
            //     });

            return new Response(filteredResult);
        }

        /// <summary>
        /// <b>Briefly</b>: Finding sum of matching percent between each student's credential fields (substrings) and given credentials string.
        /// <br /> <br />
        /// Compares all student's credentials: FirstName, MiddleName, and SecondName using Fuzz smart comparing function.
        /// <br />
        /// Normally, 70-80% is a good match for different ways to write credentials.
        /// <br /> <br />
        /// <b>For example</b>, comparing strings "Misha" and "Mikhail" give 80%.
        /// </summary>
        /// <param name="credentials">Given credentials string to compare with.</param>
        /// <param name="studentInfoDto">Student Dto where FirstName, MiddleName, and SecondName will be substrings to compare.</param>
        /// <returns>Sum of match percents of each credential: FirstName, MiddleName and SecondName</returns>
        private int CredentialsMatchPercentSum(string credentials, StudentInfoDto studentInfoDto)
        {
            return Fuzz.PartialRatio(credentials.ToLower(), studentInfoDto.FirstName.ToLower()) +
                   Fuzz.PartialRatio(credentials.ToLower(), studentInfoDto.MiddleName.ToLower()) +
                   Fuzz.PartialRatio(credentials.ToLower(), studentInfoDto.SecondName.ToLower());
        }

        /// <summary>
        /// Works similar with <b>CredentialsMatchPercentSum</b>, but only for one credential field.
        /// </summary>
        /// <param name="credentials">Given credentials string to compare with.</param>
        /// <param name="studentCredential">One credential field which will be a substring to compare.</param>
        /// <returns></returns>
        private int OneCredentialMatchPercent(string credentials, string studentCredential)
        {
            return Fuzz.PartialRatio(credentials.ToLower(), studentCredential.ToLower());
        }
    }
}