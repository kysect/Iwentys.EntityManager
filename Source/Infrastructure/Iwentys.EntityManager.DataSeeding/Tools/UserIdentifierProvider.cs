namespace Iwentys.EntityManager.DataSeeding.Tools;

public class UserIdentifierProvider
{
    private int _id;

    public int GetIdentifier()
        => ++_id;
}