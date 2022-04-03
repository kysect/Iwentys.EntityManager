using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;

namespace Iwentys.EntityManager.MappingConfiguration.Study;

public class GroupSubjectDtoMappingProfile : Profile
{
    public GroupSubjectDtoMappingProfile()
    {
        CreateMap<GroupSubject, GroupSubjectDto>()
            .ForCtorParam(nameof(GroupSubjectDto.Subject), opt => opt.MapFrom(src => src.Subject))
            .ForCtorParam(nameof(GroupSubjectDto.StudyGroup), opt => opt.MapFrom(src => src.StudyGroup))
            .ForCtorParam(nameof(GroupSubjectDto.GithubOrganization), opt => opt.MapFrom(src => src.GithubOrganization))
            
            // TODO: Proper table link mapping
            .ForCtorParam(nameof(GroupSubjectDto.TableLink), opt => opt.MapFrom(_ => string.Empty));
    }
}