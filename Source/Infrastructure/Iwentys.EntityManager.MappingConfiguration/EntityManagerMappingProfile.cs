using AutoMapper;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Dtos;
using Iwentys.EntityManager.Dtos.ValueObjects;

namespace Iwentys.EntityManager.Application;

public class EntityManagerMappingProfile : Profile
{
    public EntityManagerMappingProfile()
    {
        CreateMap<UniversitySystemUser, UniversitySystemUserDto>();
        CreateMap<IwentysUser, IwentysUserDto>();
        CreateMap<Student, StudentDto>();
        CreateMap<StudentStatus, StudentStatusDto>();

        CreateMap<Subject, SubjectDto>();
        CreateMap<StudyGroup, StudyGroupInnerDto>();
        CreateMap<StudyGroup, StudyGroupDto>();
        CreateMap<GroupSubject, GroupSubjectDto>();

        CreateMapForMentors();
    }

    public void CreateMapForMentors()
    {
        CreateMap<IGrouping<int, GroupSubject>, SubjectTeachersDto>()
            .ForMember(s => s.Name,
                map =>
                    map.MapFrom(g => g.First().Subject.Title))
            .ForMember(s => s.SubjectId,
                map =>
                    map.MapFrom(g => g.Key))
            .ForMember(s => s.GroupTeachers,
                map =>
                    map.MapFrom(g => g.Select(x => x)));

        CreateMap<GroupSubject, GroupTeachersResponseDto>()
            .ForMember(gm => gm.GroupName,
                map =>
                    map.MapFrom(gs => gs.StudyGroup.GroupName));
        CreateMap<IwentysUser, TeacherDto>();

        CreateMap<GroupSubjectTeacher, TeacherDto>()
            .ForMember(gs => gs.Id,
                map =>
                    map.MapFrom(gsm => gsm.TeacherId))
            .ForMember(gs => gs.FirstName,
                map =>
                    map.MapFrom(gsm => gsm.Teacher.FirstName))
            .ForMember(gs => gs.MiddleName,
                map =>
                    map.MapFrom(gsm => gsm.Teacher.MiddleName))
            .ForMember(gs => gs.SecondName,
                map =>
                    map.MapFrom(gsm => gsm.Teacher.SecondName));
    }
}