using Iwentys.EntityManager.Common;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.Entities.Users;

namespace Iwentys.EntityManager.Domain.Entities.Exception;

public class InvalidGroupStudentRelationshipException : IwentysException
{
    public InvalidGroupStudentRelationshipException(StudyGroup group, Student student, string reason)
        : base($"{nameof(StudyGroup)} {group} and {nameof(Student)} {student} are in invalid relationship. {reason}") { }
}