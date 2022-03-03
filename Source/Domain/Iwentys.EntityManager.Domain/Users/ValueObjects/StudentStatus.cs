using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Domain;

[Owned]
public class StudentStatus
{
    public StudentStatus(StudentStatusType type, DateTime modifiedDate)
    {
        Type = type;
        ModifiedDate = modifiedDate;
    }
    
    public StudentStatusType Type { get; set; }
    public DateTime ModifiedDate { get; set; }
}