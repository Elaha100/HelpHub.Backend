namespace HelpHub.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    public List<HelpRequest> HelpRequests { get; set; } = new();
}