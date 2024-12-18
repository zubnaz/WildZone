namespace Domain.Models.Entities;

public class EmailVerification
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Code { get; set; }
    public DateTime EndTime { get; set; } = DateTime.UtcNow + TimeSpan.FromMinutes(5);
}
