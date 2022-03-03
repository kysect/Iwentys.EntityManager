namespace Iwentys.EntityManager.Domain.GithubOrganizations;

public class GithubOrganization : IGithubOrganization
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}