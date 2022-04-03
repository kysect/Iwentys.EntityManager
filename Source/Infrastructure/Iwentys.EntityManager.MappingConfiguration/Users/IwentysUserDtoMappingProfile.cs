using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;

namespace Iwentys.EntityManager.MappingConfiguration.Users;

public class IwentysUserDtoMappingProfile : Profile
{
    public IwentysUserDtoMappingProfile()
    {
        CreateMap<IwentysUser, IwentysUserDto>()
            .ForCtorParam(nameof(IwentysUserDto.Id), c => c.MapFrom(d => d.Id))
            .ForCtorParam(nameof(IwentysUserDto.FirstName), c => c.MapFrom(d => d.FirstName))
            .ForCtorParam(nameof(IwentysUserDto.MiddleName), c => c.MapFrom(d => d.MiddleName))
            .ForCtorParam(nameof(IwentysUserDto.SecondName), c => c.MapFrom(d => d.SecondName))
            .ForCtorParam(nameof(IwentysUserDto.IsAdmin), c => c.MapFrom(d => d.IsAdmin))
            .ForCtorParam(nameof(IwentysUserDto.GithubUsername), c => c.MapFrom(d => d.GithubUsername))
            .ForCtorParam(nameof(IwentysUserDto.CreationTime), c => c.MapFrom(d => d.CreationTime))
            .ForCtorParam(nameof(IwentysUserDto.LastOnlineTime), c => c.MapFrom(d => d.LastOnlineTime))
            .ForCtorParam(nameof(IwentysUserDto.AvatarUrl), c => c.MapFrom(d => d.AvatarUrl));
    }
}