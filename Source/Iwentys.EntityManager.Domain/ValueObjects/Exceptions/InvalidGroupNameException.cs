using Iwentys.EntityManager.Common;
using Iwentys.EntityManager.Domain.ValueObjects.Study;

namespace Iwentys.EntityManager.Domain.ValueObjects.Exceptions;

public class InvalidGroupNameException : IwentysException
{
    public InvalidGroupNameException(string value)
        : base($"Invalid {nameof(GroupName)}. Value: {value}") { }

    public InvalidGroupNameException(int course, int number)
        : base($"Invalid {nameof(GroupName)}. Value: M3{course}{number}") { }
}