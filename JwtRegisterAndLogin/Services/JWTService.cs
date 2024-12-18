using Application.Interfaces;
using Data.Enums;
using Domain.Models.ApplicationSettings;
using Domain.Models.Common;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtRegisterAndLogin.Services;
public class JWTService : IJWTService
{
    private readonly string JWTKey;
    private readonly UserManager<Stalker> userManager;

    public JWTService(IOptions<ApplicationSettings> options, UserManager<Stalker> manager)
    {
        JWTKey = options.Value.JWT_Key;
        userManager = manager;
    }
    public async Task<JWTToken> GenerateJWTToken(Stalker stalker)
    {
        var isLeader = await userManager.IsInRoleAsync(stalker,Enums.Roles.Leader.ToString());
        var claims = new List<Claim>()
        {
            new Claim("Id",stalker.Id.ToString()),
            new Claim("Alias",stalker.Alias),
            new Claim("Role", isLeader == true ? "Leader" : "Stalker"),
        };
        var token = new JwtSecurityToken(
            claims : claims,
            notBefore: DateTime.UtcNow,
            expires:DateTime.UtcNow.AddDays(1),
            signingCredentials : new SigningCredentials(
            new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(JWTKey)
                ),
            SecurityAlgorithms.HmacSha256Signature)
        );
        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return new JWTToken() { Token = jwtToken };
    }

}
