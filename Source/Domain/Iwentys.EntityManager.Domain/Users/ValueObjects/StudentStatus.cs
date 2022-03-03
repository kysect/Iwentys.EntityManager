using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Domain;

[Owned]
public class StudentStatus
{
    public StudentStatus(StudentStatusType type, DateTime modifyDate)
    {
        Type = type;
        ModifyDate = modifyDate;
    }
    
    public StudentStatusType Type { get; set; }
    public DateTime ModifyDate { get; set; }
}