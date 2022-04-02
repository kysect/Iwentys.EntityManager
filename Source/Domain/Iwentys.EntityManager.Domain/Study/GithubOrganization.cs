namespace Iwentys.EntityManager.Domain;

public class GithubOrganization
{
    public string Name { get; set; }
    
    public GithubOrganization(string name)
    {   
        Name = name;
    }
}