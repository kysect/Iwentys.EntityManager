using System.ComponentModel.DataAnnotations.Schema;

namespace Iwentys.EntityManager.Domain;

public class UniversitySystemUser
{
    public UniversitySystemUser(string firstName, string middleName, string secondName)
    {
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(middleName);
        ArgumentNullException.ThrowIfNull(secondName);

        FirstName = firstName;
        MiddleName = middleName;
        SecondName = secondName;
    }

    protected UniversitySystemUser() { }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public string FirstName { get; protected init; }
    public string MiddleName { get; protected init; }
    public string SecondName { get; protected init; }
}