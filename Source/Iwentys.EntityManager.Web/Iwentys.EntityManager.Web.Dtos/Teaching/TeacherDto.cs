using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.WebApiDtos;

public record TeacherDto
{
    public int Id { get; init; }
    public TeacherType TeacherType { get; init; }
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string SecondName { get; init; }

    public TeacherDto()
    {
    }

    public TeacherDto(int id, TeacherType teacherType, string firstName, string middleName, string secondName)
    {
        TeacherType = teacherType;
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        SecondName = secondName;
    }
};