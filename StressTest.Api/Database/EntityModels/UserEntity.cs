namespace StressTest.Api.Database.EntityModels;

public class UserEntity
{
    public Guid UserId { get;private set; }
    public string FirstName { get;private set; }
    public string FamilyName { get;private set; }
    public string UserName { get;private set; }
    
}