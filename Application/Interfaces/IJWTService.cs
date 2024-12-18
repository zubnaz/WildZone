using Domain.Models.Common;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Interfaces;
public interface IJWTService
{
    public Task<JWTToken> GenerateJWTToken(Stalker stalker);
}
