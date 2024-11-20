using Microsoft.Extensions.Configuration.UserSecrets;

class User
{
    public Guid Id { get; set; }
    public User(Guid id)
    {
        Id = id;
    }
}