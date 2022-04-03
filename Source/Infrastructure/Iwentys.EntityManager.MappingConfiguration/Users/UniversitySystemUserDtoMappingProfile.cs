using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;

namespace Iwentys.EntityManager.MappingConfiguration.Users;

public class UniversitySystemUserDtoMappingProfile : Profile
{
    public UniversitySystemUserDtoMappingProfile()
    {
        CreateMap<UniversitySystemUser, UniversitySystemUserDto>()
            .ForCtorParam(nameof(UniversitySystemUserDto.Id), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(UniversitySystemUserDto.FirstName), opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam(nameof(UniversitySystemUserDto.MiddleName), opt => opt.MapFrom(src => src.MiddleName))
            .ForCtorParam(nameof(UniversitySystemUserDto.SecondName), opt => opt.MapFrom(src => src.SecondName));
    }
}