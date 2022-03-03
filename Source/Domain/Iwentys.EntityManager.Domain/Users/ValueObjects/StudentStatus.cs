namespace Iwentys.EntityManager.Domain;

public class StudentStatus
{
    public StudentStatus(StudentStatusType type, DateTime modifyDate)
    {
        Type = type;
        ModifyDate = modifyDate;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public StudentStatusType Type { get; set; }
    public DateTime ModifyDate { get; set; }
}