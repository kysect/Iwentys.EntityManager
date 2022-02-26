using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.Dtos;

public record TeacherDto(
    int Id,
    TeacherType TeacherType,
    string FirstName,
    string MiddleName,
    string SecondName);