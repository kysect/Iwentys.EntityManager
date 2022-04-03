using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;

namespace Iwentys.EntityManager.MappingConfiguration.Users;

public class StudentDtoMappingProfile : Profile
{
    public StudentDtoMappingProfile()
    {
        CreateMap<Student, StudentDto>()
            .ForCtorParam(nameof(StudentDto.Id), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(StudentDto.FirstName), opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam(nameof(StudentDto.MiddleName), opt => opt.MapFrom(src => src.MiddleName))
            .ForCtorParam(nameof(StudentDto.SecondName), opt => opt.MapFrom(src => src.SecondName))
            .ForCtorParam(nameof(StudentDto.IsAdmin), opt => opt.MapFrom(src => src.IsAdmin))
            .ForCtorParam(nameof(StudentDto.GithubUsername), opt => opt.MapFrom(src => src.GithubUsername))
            .ForCtorParam(nameof(StudentDto.CreationTime), opt => opt.MapFrom(src => src.CreationTime))
            .ForCtorParam(nameof(StudentDto.LastOnlineTime), opt => opt.MapFrom(src => src.LastOnlineTime))
            .ForCtorParam(nameof(StudentDto.AvatarUrl), opt => opt.MapFrom(src => src.AvatarUrl))
            .ForCtorParam(nameof(StudentDto.Type), opt => opt.MapFrom(src => src.Type))
            .ForCtorParam(nameof(StudentDto.GroupId), opt => opt.MapFrom(src => src.Group.Id))
            .ForCtorParam(nameof(StudentDto.StudentStatus), opt => opt.MapFrom(src => src.StudentStatus));
    }
}