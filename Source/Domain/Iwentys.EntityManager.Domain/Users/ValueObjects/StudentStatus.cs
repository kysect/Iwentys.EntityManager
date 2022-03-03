namespace Iwentys.EntityManager.Domain;

public class StudentStatus
{
    public StudentStatus(StudentStatusType status, DateTime statusStart)
    {
        Status = status;
        StatusStart = statusStart;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public StudentStatusType Status { get; set; }
    public DateTime StatusStart { get; set; }
}