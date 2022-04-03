using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos.ValueObjects;

namespace Iwentys.EntityManager.MappingConfiguration.Users.ValueObjects;

public class StudentStatusDtoMappingConfiguration : Profile
{
    public StudentStatusDtoMappingConfiguration()
    {
        CreateMap<StudentStatus, StudentStatusDto>()
            .ForCtorParam(nameof(StudentStatusDto.Type), opt => opt.MapFrom(src => src.Type.ToString()))
            .ForCtorParam(nameof(StudentStatusDto.ModifiedDate), opt => opt.MapFrom(src => src.ModifiedDate));
    }
}