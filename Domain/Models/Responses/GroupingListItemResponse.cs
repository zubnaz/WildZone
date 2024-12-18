namespace Domain.Models.Responses;

public class GroupingListItemResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Logo { get; set; }
}
