﻿namespace Domain.Models.Requests;

public record LoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
