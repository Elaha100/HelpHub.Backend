namespace HelpHub.Domain.Entities;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public List<HelpRequest> HelpRequests { get; set; } = new();
}