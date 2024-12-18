namespace Domain.Models.Requests;

public record RegisterRequest
{
    public required string Email { get; set; }
    public required string Alias { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
    public Guid GroupingId { get; set; }
    public Guid AvatarId { get; set; }
    
}
