using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;

namespace Iwentys.EntityManager.MappingConfiguration.Study;

public class SubjectDtoMappingConfiguration : Profile
{
    public SubjectDtoMappingConfiguration()
    {
        CreateMap<Subject, SubjectDto>()
            .ForCtorParam(nameof(SubjectDto.Id), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(SubjectDto.Title), opt => opt.MapFrom(src => src.Title));
    }
}