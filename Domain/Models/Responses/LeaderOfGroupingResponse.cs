namespace Domain.Models.Responses;
public record LeaderOfGroupingResponse
{
    public Guid Id { get; set; }
    public required string Allies { get; set; }
    public required string Grouping { get; set; }
    public required string Rang { get; set; }
    public required string Avatar { get; set; }
    public required int Power { get; set; }
}

