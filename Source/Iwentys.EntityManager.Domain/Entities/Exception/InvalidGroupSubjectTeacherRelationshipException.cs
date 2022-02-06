using Iwentys.EntityManager.Common;
using Iwentys.EntityManager.Domain.Entities.Teaching;
using Iwentys.EntityManager.Domain.Entities.Users;

namespace Iwentys.EntityManager.Domain.Entities.Exception;

public class InvalidGroupSubjectTeacherRelationshipException : IwentysException
{
    public InvalidGroupSubjectTeacherRelationshipException(GroupSubject groupSubject, Teacher teacher, string reason)
        : base($"{nameof(GroupSubject)} {groupSubject} and {nameof(Teacher)} {teacher} have invalid relationship. {reason}") { }
}