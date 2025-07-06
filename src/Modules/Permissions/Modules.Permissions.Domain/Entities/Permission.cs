namespace Permissions.Domain.Entities;

public class Permission
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }

    private Permission()
    {
    }

    public Permission(string name, string description, string category)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description;
        Category = category;
    }

    public void Update(string name, string description, string category)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description;
        Category = category;
    }
}