using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;

namespace Iwentys.EntityManager.MappingConfiguration.Study;

public class StudyGroupDtoMappingConfiguration : Profile
{
    public StudyGroupDtoMappingConfiguration()
    {
        CreateMap<StudyGroup, StudyGroupDto>()
            .ForCtorParam(nameof(StudyGroupDto.Id), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(StudyGroupDto.GroupName), opt => opt.MapFrom(src => src.GroupName.ToString()))
            .ForCtorParam(nameof(StudyGroupDto.GroupAdminId), opt => opt.MapFrom(src => src.GroupAdminId))
            .ForCtorParam(nameof(StudyGroupDto.Students), opt => opt.MapFrom(src => src.Students))
            .ForCtorParam(nameof(StudyGroupDto.Subjects), opt => opt.MapFrom(src => src.GroupSubjects));
    }
}