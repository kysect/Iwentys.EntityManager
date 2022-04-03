using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;

namespace Iwentys.EntityManager.MappingConfiguration.Study;

public class StudyGroupInnerDtoMappingConfiguration : Profile
{
    public StudyGroupInnerDtoMappingConfiguration()
    {
        CreateMap<StudyGroup, StudyGroupInnerDto>()
            .ForCtorParam(nameof(StudyGroupInnerDto.Id), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(StudyGroupInnerDto.GroupName), opt => opt.MapFrom(src => src.GroupName))
            .ForCtorParam(nameof(StudyGroupInnerDto.GroupAdminId), opt => opt.MapFrom(src => src.GroupAdminId));
    }
}