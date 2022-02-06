using Iwentys.EntityManager.Common;
using Iwentys.EntityManager.Domain.ValueObjects.Users;

namespace Iwentys.EntityManager.Domain.ValueObjects.Exceptions;

public class InvalidGraduationYearException : IwentysException
{
    public InvalidGraduationYearException(string value)
        : base($"Invalid {nameof(GraduationYear)}. Value: {value}") { }
}