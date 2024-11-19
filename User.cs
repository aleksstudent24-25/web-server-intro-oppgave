using Microsoft.Extensions.Configuration.UserSecrets;

class User
{
    public Guid Id { get; set; }
    public User(Guid id = new Guid())
    {
        Id = id;
    }

    public Guid updateId(Guid newId)
    {
        Id = newId;
        return Id;
    }
}