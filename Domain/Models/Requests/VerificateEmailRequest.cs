namespace Domain.Models.Requests;

public record VerificateEmailRequest
{
    public required string Email { get; set; }
    public required string Code { get; set; }
}
