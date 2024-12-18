namespace Domain.Models.Responses;

public record AvatarByGroupingIdResponse
{
    public Guid AvatarId { get; set; }
    public required string Name { get; set; }
}
